using Amazon.S3;
using Amazon.S3.Model;
using Avalonia.Threading;
using DynamicData;
using FluentScheduler;
using Flurl;
using Flurl.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OpenEncoder.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<MyCollection>? _MyCollection;
        public ObservableCollection<MyCollection> MyCollection => _MyCollection ??= new ObservableCollection<MyCollection>();

        private ObservableCollection<Status>? _Status;
        public ObservableCollection<Status> Status => _Status ??= new ObservableCollection<Status>();

        private ObservableCollection<Health>? _Health;
        public ObservableCollection<Health> Health => _Health ??= new ObservableCollection<Health>();

        private ObservableCollection<Node>? _Items;
        public ObservableCollection<Node> Items => _Items ??= new ObservableCollection<Node>();

        private ObservableCollection<Node>? _SelectedItems;
        public ObservableCollection<Node> SelectedItems => _SelectedItems ??= new ObservableCollection<Node>();

        public MainWindowViewModel()
        {
            JobManager.Initialize();
            JobManager.AddJob(() =>
                {
                    Context context = new();

                    bool dbHealth = true, workerHealth = true;

                    try
                    {
                        BalenaCloud? balena = JsonSerializer.Deserialize<BalenaCloud>(Url.Parse("https://api.balena-cloud.com/v6/device?$select=device_name,uuid").WithOAuthBearerToken("jiHlgqMWAoirXppSThDAO7rD6Ungg2XA").GetStringAsync().Result);
                        HeartBeat? h = JsonSerializer.Deserialize<HeartBeat>(Url.Parse($"https://{balena?.d.First(l => l.device_name == "OpenEncoder").uuid}.balena-devices.com/api/HeartBeat").GetStringAsync().Result);

                        if (!(h?.db == "OK"))
                        {
                            dbHealth = false;
                        }

                        if (!(h?.worker == "OK"))
                        {
                            workerHealth = false;
                        }
                    }
                    catch
                    {
                        dbHealth = false;
                        workerHealth = false;
                    }
                    List<MyCollection> collections = context.PublicJobs.Where(a => a.Status != "completed").OrderBy(a => a.Status).Select(a => new MyCollection { id = a.Id, progress = a.PublicEncode.Progress, source = Path.GetFileName(a.Source), status = a.Status }).ToList();
                    List<Status> statuses = context.PublicJobs.GroupBy(a => a.Status).Select(a => new Status { count = a.Count(), nome = a.First().Status, porcentagem = Math.Round((double)(a.Count() * 100 / context.PublicJobs.Count())) }).ToList();
                    Dispatcher.UIThread.InvokeAsync(() =>
                      {
                          MyCollection.Clear();
                          Status.Clear();
                          Health.Clear();
                          MyCollection.AddRange(collections);
                          Status.AddRange(statuses);
                          Health.Add(new Health { nome = "Database", status = dbHealth });
                          Health.Add(new Health { nome = "Worker", status = workerHealth });
                      });
                },
                s => s.ToRunNow().AndEvery(5).Seconds());
            Items.AddRange(GetSubfolders());
        }

        private ObservableCollection<Node> GetSubfolders()
        {
            ObservableCollection<Node> subfolders = new ObservableCollection<Node>();
            Context context = new();
            string Endpoint = context.PublicSettings.Where(a => a.PublicSettingsOption_SettingsOptionId.Name == "S3_ENDPOINT").Select(a => a.Value).First();
            string AccessKey = context.PublicSettings.Where(a => a.PublicSettingsOption_SettingsOptionId.Name == "S3_ACCESS_KEY").Select(a => a.Value).First();
            string SecretKey = context.PublicSettings.Where(a => a.PublicSettingsOption_SettingsOptionId.Name == "S3_SECRET_KEY").Select(a => a.Value).First();
            string InboundBuket = context.PublicSettings.Where(a => a.PublicSettingsOption_SettingsOptionId.Name == "S3_INBOUND_BUCKET").Select(a => a.Value).First();
            AmazonS3Client amazonS3Client = new(AccessKey, SecretKey, new AmazonS3Config { AuthenticationRegion = "us-east-1", ServiceURL = Endpoint, ForcePathStyle = true });
            amazonS3Client.ListObjectsAsync(new ListObjectsRequest { BucketName = InboundBuket, MaxKeys = int.MaxValue }).Result.S3Objects.ForEach(dir =>
            {
                if (!context.PublicJobs.Where(a => a.Source == $"s3://{InboundBuket}/{dir.Key}").Any())
                {
                    subfolders.Add(new Node($"s3://{InboundBuket}/{dir.Key}"));
                }
            });
            return subfolders;
        }
    }
}
