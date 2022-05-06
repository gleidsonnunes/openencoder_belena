using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Model;
using ReactiveUI;
using System;
using System.Globalization;
using System.Linq;

namespace OpenEncoder.ViewModels
{
    public class IconValueConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? textvalue = value as string;
            switch (textvalue)
            {
                case "encoding":
                    return new PathIcon { Data = ViewModelBase.presence_blocked_regular }; //(char)10060;// "\u274c";
                case "error":
                    unchecked
                    {
                        return new PathIcon { Data = ViewModelBase.arrow_rotate_counterclockwise_regular };//(char)128260; //"\ud83d\udd04";
                    }
                case "cancelled":
                    unchecked
                    {
                        return new PathIcon { Data = ViewModelBase.arrow_rotate_counterclockwise_regular };//(char)128260; //"\ud83d\udd04";
                    }
                case "downloading":
                    return new PathIcon { Data = ViewModelBase.presence_blocked_regular }; //(char)10060;// "\u274c";
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BackgroundValueConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? textvalue = value as string;
            switch (textvalue)
            {
                case "encoding":
                    return Brush.Parse("Red");
                case "error":
                    return Brush.Parse("Blue");
                case "cancelled":
                    return Brush.Parse("Blue");
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BackgroundValueConverter2 : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            switch (value)
            {
                case false:
                    return Brush.Parse("Red");
                case true:
                    return Brush.Parse("Green");
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CommandValueConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? textvalue = value as string;
            switch (textvalue)
            {
                case "encoding":
                    return ReactiveCommand.Create<int>(Cancel);
                case "error":
                    return ReactiveCommand.Create<int>(Restart);
                case "cancelled":
                    return ReactiveCommand.Create<int>(Restart);
                case "downloading":
                    return ReactiveCommand.Create<int>(Cancel);
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        private void Cancel(int parameter)
        {
            Context context = new();
            PublicJob job = context.PublicJobs.First(a => a.Id == parameter);
            job.Status = "cancelled";
            PublicEncode encode = context.PublicEncodes.First(a => a.JobId == parameter);
            encode.Option = "{}";
            encode.Probe = "{}";
            encode.Progress = 0;
            context.SubmitChanges();
        }

        private void Restart(int parameter)
        {
            Context context = new();
            PublicJob job = context.PublicJobs.First(a => a.Id == parameter);
            job.Status = "queued";
            PublicEncode encode = context.PublicEncodes.First(a => a.JobId == parameter);
            encode.Option = "{}";
            encode.Probe = "{}";
            encode.Progress = 0;
            context.SubmitChanges();
        }
    }

    public class VisibilityValueConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string? textvalue = value as string;
            switch (textvalue)
            {
                case "encoding":
                    return true;
                case "error":
                    return true;
                case "cancelled":
                    return true;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
