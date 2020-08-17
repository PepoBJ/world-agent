namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan date)
            {
                return date.ToString(@"hh\:mm").ToUpper();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
