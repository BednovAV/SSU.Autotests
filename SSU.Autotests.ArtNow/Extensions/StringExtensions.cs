namespace SSU.Autotests.ArtNow.Extensions;

public static class StringExtensions
{
    public static string RemoveNewLine(this string value)
    {
        return value.Replace("\r\n", " ");
    }
}