using LcdGames;
using MarioBros.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MarioBros.Converters
{
    public class LcdState2VisibilityConverter: IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var state = (LcdGamePinState)value;
            return state == LcdGamePinState.On ? Visibility.Visible : Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var visibility = (Visibility)value;
            return visibility == Visibility.Visible ? LcdGamePinState.On : LcdGamePinState.Off;
        }
    }
}
