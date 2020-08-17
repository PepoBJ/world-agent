namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    using AppWorldAgent.Infrastructure.Extensions;

    public class DatetimeFriendlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date.Year == 1)
                    return string.Empty;

                return date.DateFriendly();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

