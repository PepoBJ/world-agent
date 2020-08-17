namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Globalization;
    using System.IO;
    using Xamarin.Forms;
    public class ByteToImageFieldConverter : IValueConverter
    {
        public object Convert(object imageByte, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource retSource = null;
            if (imageByte != null)
            {
                byte[] imageAsBytes = (byte[])imageByte;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return retSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
