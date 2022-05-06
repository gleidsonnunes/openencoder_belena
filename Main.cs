using CommandLine;
using FluentScheduler;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace openencoder;
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
        Parser.Default.ParseArguments<Options>(args)
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
                       IHost host = Host.CreateDefaultBuilder(args)
                        .ConfigureServices((context, services) =>
                        {
                            services.AddSingleton<MonitorLoop>();
                            services.AddHostedService<QueuedHostedService>();
                            services.AddSingleton<IBackgroundTaskQueue>(_ =>
                            {
                                if (!int.TryParse(context.Configuration["QueueCapacity"], out var queueCapacity))
                                {
                                    queueCapacity = 100;
                                }

                                return new DefaultBackgroundTaskQueue(queueCapacity);
                            });
                        }).Build();
                       MonitorLoop monitorLoop = host.Services.GetRequiredService<MonitorLoop>()!;
                       monitorLoop.StartMonitorLoop();
                       host.Run();
                   }
               });
    }
}