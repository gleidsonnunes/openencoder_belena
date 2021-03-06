using FluentScheduler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.RegularExpressions;

namespace openencoder;

public class MonitorLoop
{
    private readonly IBackgroundTaskQueue _taskQueue;
    private readonly ILogger<MonitorLoop> _logger;
    private readonly CancellationToken _cancellationToken;

    public MonitorLoop(
        IBackgroundTaskQueue taskQueue,
        ILogger<MonitorLoop> logger,
        IHostApplicationLifetime applicationLifetime)
    {
        _taskQueue = taskQueue;
        _logger = logger;
        _cancellationToken = applicationLifetime.ApplicationStopping;
    }

    public void StartMonitorLoop()
    {
        _logger.LogInformation($"{nameof(Monitor)} loop is starting.");
        try
        {
            JobManager.Initialize();
            IConfigurationRoot config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            OpenEncoderModel model = new();
            IModel channel = new ConnectionFactory { Uri = new Uri(config.GetValue<string>("RMQConnectionString")) }.CreateConnection().CreateModel();
            Task.Run(() => MonitorAsync(model, channel));
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(), ex, "");
        }
    }

    private async void MonitorAsync(OpenEncoderModel model, IModel channel)
    {
        JobManager.AddJob(async () => await _taskQueue.QueueBackgroundWorkItemAsync((token) => BuildWorkItem(model, channel, token)), s => s.ToRunNow().AndEvery(5).Seconds());
        while (true)
        {
            await Task.Delay(5000);
            if (_cancellationToken.IsCancellationRequested)
            {
                JobManager.RemoveAllJobs();
                break;
            }

        }
        await Task.FromCanceled(_cancellationToken);
    }

    private ValueTask BuildWorkItem(OpenEncoderModel model, IModel channel, CancellationToken token)
    {
        return new ValueTask(Task.Factory.StartNew(() =>
        {
            try
            {
                try
                {
                    if (!model.queue_jobs.Any() || !model.queue_jobs.Local.Any())
                    {
                        List<jobs> jobs = model.jobs.Where(a => (new string[] { "queued", "restarting" }).Contains(a.status)).ToList();
                        jobs.ExceptBy(model.queue_jobs.Select(a => a.guid), (b) => b.guid).ToList().ForEach(a =>
                         {
                             if (!model.queue_jobs.Local.Any(b => b.guid == a.guid))
                             {
                                 model.queue_jobs.Add(new queue_jobs { destination = a.destination, guid = a.guid, preset = a.preset, source = a.source });
                             }
                             model.SaveChanges();
                         });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(new EventId(), ex, "");
                }
                model.queue_jobs.ToList().ForEach(a =>
                {
                    IBasicProperties props = channel.CreateBasicProperties();
                    props.Headers = new Dictionary<string, object>
                {
                    { "x-deduplication-header", true }
                };
                    channel.BasicPublish(exchange: "", routingKey: "queue", basicProperties: props, body: Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{\"guid\": \"{a.guid}\", \"preset\": \"{a.preset}\", \"source\": \"{a.source}\", \"destination\": \"{a.destination}\"}}"))));
                });
                EventingBasicConsumer? consumer = new(channel);
                consumer.Received += (m, ea) =>
                {
                    byte[]? body = ea.Body.ToArray();
                    string? message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation(message: message);
                    string guid = Regex.Matches(message, @"([a-z0-9]{8}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{12})").First().Value;
                    model.queue_jobs.Remove(model.queue_jobs.First(a => a.guid == guid));
                    model.SaveChanges();
                };
                channel.BasicConsume(queue: "downstream", autoAck: true, consumer: consumer);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, "");
            }
        }, token));
    }
}