using System;
using System.Windows;
using System.Windows.Data;

namespace MarioBros.Converters
{
    public class LostLives2VisibilityConverter: IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var intValue = (int)value;
            var intParameter = ToInt32(parameter);
            return intValue >= intParameter ? Visibility.Visible : Visibility.Hidden;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var visibility = (Visibility)value;
            var intParameter = ToInt32(parameter);
            return visibility == Visibility.Visible ? parameter : 0;
        }

        private int ToInt32(object v)
        {
            if (v is int)
                return (int)v;
            else if (v is string)
                return int.Parse((string)v);
            else
                throw new ArgumentException("Type not supported");
        }
    }
}
