namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    public class DateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date.Year == 1)
                    return string.Empty;

                return date.ToString("dd/MM/yyyy H:mm");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            return value;
        }
    }
}
