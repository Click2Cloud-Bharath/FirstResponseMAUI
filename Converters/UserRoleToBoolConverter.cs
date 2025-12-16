using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Converters
{
    public class UserRoleToBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return false;
            var roleName = value.ToString();

            if (roleName.Equals("Supervisor", StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
