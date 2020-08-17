namespace AppWorldAgent.Infrastructure.Converters
{
    using AppWorldAgent.Infrastructure.Extensions;
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (date.Year == 1)
                    return string.Empty;

                return date.DateFriendly().Replace("de ", "").Replace("del ", "");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
