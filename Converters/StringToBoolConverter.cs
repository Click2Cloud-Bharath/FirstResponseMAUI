using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return false;

            string stringValue = value.ToString();

            if (string.IsNullOrEmpty(stringValue)) return false;

            if (parameter == null) return true;

            string parameterValue = parameter.ToString();
            return stringValue.Equals(parameterValue);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
