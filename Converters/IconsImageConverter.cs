using FirstResponseMAUI.Models;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class IconsImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;
            IncidentType type = (IncidentType)value;
            string iconName;

            switch (type)
            {
                case IncidentType.Alert: iconName = "icon_alert"; break;
                case IncidentType.Animal: iconName = "icon_animal"; break;
                case IncidentType.Arrest: iconName = "icon_arrest"; break;
                case IncidentType.Car: iconName = "icon_car"; break;
                case IncidentType.Fire: iconName = "icon_fire"; break;
                case IncidentType.OfficerRequired: iconName = "icon_officer"; break;
                case IncidentType.Stranger: iconName = "icon_stranger"; break;
                default: iconName = "icon_other"; break;
            }

            return $"{iconName}.png";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
