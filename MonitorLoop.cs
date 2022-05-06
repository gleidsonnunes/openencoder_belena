﻿using FluentScheduler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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
            _logger.LogError(new EventId(),ex,"");
        }
    }

    private async void MonitorAsync(OpenEncoderModel model, IModel channel)
    {
        JobManager.AddJob(async  () => await _taskQueue.QueueBackgroundWorkItemAsync((token) => BuildWorkItem(token, model, channel)), s => s.ToRunNow().AndEvery(5).Seconds());
        while (true)
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                JobManager.RemoveAllJobs();
                break;
            }

        }
        await Task.FromCanceled(_cancellationToken);
    }

    private ValueTask BuildWorkItem(CancellationToken token, OpenEncoderModel model, IModel channel)
    {
        return new ValueTask(Task.Factory.StartNew(() =>
        {
            try
            {

                if (!model.queue_job.Any())
                {
                    List<jobs> jobs = model.jobs.Where(a => (new string[] { "queued", "restarting" }).Contains(a.status)).ToList();
                    jobs.ForEach(a =>
                    {
                        model.queue_job.Add(new queue_job { destination = a.destination, guid = a.guid, preset = a.preset, source = a.source });
                        model.SaveChanges();
                    });
                }
                model.queue_job.ToList().ForEach(a =>
                {
                    IBasicProperties props = channel.CreateBasicProperties();
                    props.Headers = new Dictionary<string, object>
                {
                    { "x-deduplication-header", true }
                };
                    channel.BasicPublish(exchange: "", routingKey: "queue", basicProperties: props, body: Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{\"guid\": \"{a.guid}\", \"preset\": \"{a.preset}\", \"source\": \"{a.source}\", \"destination\": \"{a.destination}\"}}"))));
                    model.queue_job.Remove(a);
                    model.SaveChanges();
                });
                EventingBasicConsumer? consumer = new(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[]? body = ea.Body.ToArray();
                    string? message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                };
                channel.BasicConsume(queue: "downstream", autoAck: true, consumer: consumer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }, token));
    }
}