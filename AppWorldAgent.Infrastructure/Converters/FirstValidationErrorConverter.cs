﻿namespace AppWorldAgent.Infrastructure.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Xamarin.Forms;

    public class FirstValidationErrorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ICollection<string> errors && errors.Count > 0 ? errors.ElementAt(0) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
