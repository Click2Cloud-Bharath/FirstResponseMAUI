using System.Text.RegularExpressions;

namespace FirstResponseMAUI.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string ToFriendlyCase(this string value)
        {
            return Regex.Replace(value, "(?!^)([A-Z])", " $1");
        }
    }
}
