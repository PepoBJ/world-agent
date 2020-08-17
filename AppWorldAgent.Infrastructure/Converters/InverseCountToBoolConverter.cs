using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppWorldAgent.Infrastructure.Converters
{
    public class InverseCountToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                long count = System.Convert.ToInt64(value);

                return count == 0;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
