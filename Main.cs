using CommandLine;
using FluentScheduler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace openencoder
{
    public class Program
    {
        public class Options
        {
            [Option('s', "server", Required = false, HelpText = "Start in server mode")]
            public bool Server { get; set; }

            [Option('w', "worker", Required = false, HelpText = "Start in worker mode")]
            public bool Worker { get; set; }
        }

        private static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_URLS", string.Empty);
            Console.Title = "Openencoder - Open Source Cloud Encoder";
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                   {
                       if (o.Server)
                       {
                           Console.WriteLine("Starting server...");
                           Console.WriteLine($"Running with {Environment.ProcessorCount} CPUs");
                           _ = new Server(args);
                       }
                       else if (o.Worker)
                       {
                           Console.WriteLine("Starting worker...");
                           Console.WriteLine($"Running with {Environment.ProcessorCount} CPUs");
                           IHost host = Host.CreateDefaultBuilder(args).Build();
                           JobManager.Initialize();
                           JobManager.AddJob(
                               () =>
                               {
                                   try
                                   {
                                       using OpenEncoderModel model = new();
                                       List<jobs> jobs = model.jobs.Where(a => (new string[] { "queued", "restarting" }).Contains(a.status)).ToList();
                                       IConfigurationRoot config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
                                       using (IModel channel = new ConnectionFactory { HostName = config.GetValue<string>("RMQHost"), Password = config.GetValue<string>("RMQPassword"), UserName = config.GetValue<string>("RMQUsername"), VirtualHost = config.GetValue<string>("RMQVHost") }.CreateConnection().CreateModel())
                                       {
                                           jobs.ForEach(a =>
                                           {
                                               IBasicProperties props = channel.CreateBasicProperties();
                                               props.Headers = new Dictionary<string, object>
                                               {
                                                   { "x-deduplication-header", true }
                                               };
                                               channel.BasicPublish(exchange: "", routingKey: "queue", basicProperties: props, body: Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{\"guid\": \"{a.guid}\", \"preset\": \"{a.preset}\", \"source\": \"{a.source}\", \"destination\": \"{a.destination}\"}}"))));
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
                                   }
                                   catch (Exception ex)
                                   {
                                       Console.WriteLine(ex);
                                   }
                               },
                               s => s.ToRunNow().AndEvery(5).Seconds()
                           );
                           host.Run();
                       }
                   });
        }
    }
}
