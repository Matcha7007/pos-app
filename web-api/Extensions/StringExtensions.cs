namespace web_api.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmty(this string s) {
            return string.IsNullOrEmpty(s.Trim());
        }
    }
}