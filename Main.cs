using CommandLine;
using FluentScheduler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace openencoder
{
    public class Program
    {
        private static readonly OpenEncoderModel model = new();
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
                                   ConnectionFactory factory = new() { Uri = new("amqp://gleidson:Gleidson@gleidson-nunes.ddns.net:5672") };
                                   List<jobs> jobs = model.jobs.Where(a => (new string[] { "queued", "restarting" }).Contains(a.status)).ToList();
                                   using IConnection connection = factory.CreateConnection();
                                   using IModel channel = connection.CreateModel();
                                   List<jobs> queued = new();
                                   jobs.Except(queued).ToList().ForEach(a =>
                                   {
                                       queued.Add(a);
                                       channel.BasicPublish(exchange: "", routingKey: "queue", basicProperties: null, body: Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes($"{{\"guid\": \"{a.guid}\", \"preset\": \"{a.preset}\", \"source\": \"{a.source}\", \"destination\": \"{a.destination}\"}}"))));
                                   });
                                   EventingBasicConsumer? consumer = new(channel);
                                   consumer.Received += (model, ea) =>
                                   {
                                       byte[]? body = ea.Body.ToArray();
                                       string? message = Encoding.UTF8.GetString(body);
                                       Console.WriteLine(message);
                                   };
                                   channel.BasicConsume(queue: "downstream",
                                                        autoAck: false,
                                                        consumer: consumer);
                               },
                               s => s.ToRunNow().AndEvery(5).Seconds()
                           );
                           host.Run();
                       }
                   });
        }
    }
}
