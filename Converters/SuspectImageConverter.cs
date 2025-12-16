using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class SuspectImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;
            string suspectName = (string)value;
            suspectName = suspectName.Replace(" ", string.Empty);

            // In MAUI, images in Resources/Images are flattened. 
            // Assuming standard naming convention suspect_{name}.png
            return $"suspect_{suspectName}.png";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
