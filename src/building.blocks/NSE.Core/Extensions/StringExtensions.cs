namespace NSE.Core.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
        public static bool IsNumeric(this string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
