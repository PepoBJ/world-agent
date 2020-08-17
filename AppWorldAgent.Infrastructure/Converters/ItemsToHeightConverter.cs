using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppWorldAgent.Infrastructure.Converters
{
    public class ItemsToHeightConverter : IValueConverter
    {
        private const long ItemHeight = 156;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int)
            {
                return System.Convert.ToInt64(value) * ItemHeight;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
