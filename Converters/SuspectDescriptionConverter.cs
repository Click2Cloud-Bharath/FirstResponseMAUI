using FirstResponseMAUI.Models;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class SuspectDescriptionConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && value is SuspectModel)
            {
                var suspect = value as SuspectModel;
                return $"{suspect.EyeColor} eyes, {suspect.HairColor} hair";
            }
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
