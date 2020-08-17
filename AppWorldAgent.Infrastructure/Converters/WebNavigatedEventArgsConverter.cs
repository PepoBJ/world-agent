namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class WebNavigatedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is WebNavigatedEventArgs eventArgs))
                throw new ArgumentException("Expected WebNavigatedEventArgs as value", "value");

            return eventArgs.Url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
