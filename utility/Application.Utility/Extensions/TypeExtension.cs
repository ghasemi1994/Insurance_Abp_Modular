

namespace Application.Utility.Extensions;

public static class TypeExtension
{
    public static int? ToInt32(this object text)
         => Convert.ToInt32(text);

    public static int ToInt32(this string text)
        => Convert.ToInt32(text);

    public static long ToInt64(this object text)
        => Convert.ToInt64(text);

    public static decimal ToRound(this decimal number, int digit = 0)
    {
        return Math.Round(number, digit);
    }

    public static decimal ToRoundDown(this decimal number)
    {
        return Math.Floor(number);
    }

    public static List<int?> ToListInt32(this List<string> strings)
    {
        return strings.Select(s => Int32.TryParse(s, out int n) ? n : (int?)null).ToList();
    }
}
