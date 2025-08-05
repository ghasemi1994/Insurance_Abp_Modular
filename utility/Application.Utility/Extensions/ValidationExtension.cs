

namespace Application.Utility.Extensions;

public static class ValidationExtension
{
    public static bool NotEmptyOrNull(this string text)
    {
        return !string.IsNullOrWhiteSpace(text);
    }

    public static bool EmptyOrNull(this string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }

    public static bool IsDigitsOnly(this string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
}
