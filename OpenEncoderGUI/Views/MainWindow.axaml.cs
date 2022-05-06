using Avalonia.Controls;
using Avalonia.Interactivity;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using Model;
using System;
using System.Linq;

namespace OpenEncoder.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddToConvert(object sender, RoutedEventArgs e)
        {
            try
            {
                Context context = new();
                TextBox text = this.FindControl<TextBox>("file");
                if (!string.IsNullOrEmpty(text.Text))
                {
                    string guid = Guid.NewGuid().ToString();
                    string OutboundBuket = context.PublicSettings.Where(a => a.PublicSettingsOption_SettingsOptionId.Name == "S3_OUTBOUND_BUCKET").Select(a => a.Value).First();
                    context.PublicJobs.InsertOnSubmit(new PublicJob { Destination = $"s3://{OutboundBuket}/", CreatedDate = DateTime.Now, Guid = guid, Preset = "x265", Status = "queued", Source = text.Text });
                    context.SubmitChanges();
                    int id = context.PublicJobs.First(a => a.Guid == guid).Id;
                    context.PublicEncodes.InsertOnSubmit(new PublicEncode { JobId = id, Option = "{}", Probe = "{}", Progress = 0 });
                    context.SubmitChanges();
                    MessageBoxManager.GetMessageBoxStandardWindow("Sucesso", "Arquivo adicionado com sucesso para conversão", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Plus).Show();
                }
                else
                {
                    MessageBoxManager.GetMessageBoxStandardWindow("Erro", "Selecione um arquivo primeiro", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBoxManager.GetMessageBoxStandardWindow("Erro", $"Erro ao inserir arquivo para conversão: {ex.Message}", ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error).Show();
            }

        }
    }
}
