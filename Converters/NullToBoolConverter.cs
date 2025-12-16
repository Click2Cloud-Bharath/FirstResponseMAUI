using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (string?)parameter == "Inverse" ? value != null : value == null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
