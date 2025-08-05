using System.ComponentModel.DataAnnotations;


namespace Application.Utility.Extensions;

public static class EnumExtension
{
    public static int GetLength(this Enum value)
    {
        if (value == null) return 0;
        return Enum.GetValues(value.GetType()).Length;
    }

    public static string GetDisplayName(this Enum value)
    {
        if (value == null) return string.Empty;

        try
        {
            var field = value.GetType().GetField(value.ToString());

            var displayAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            return displayAttribute != null ? displayAttribute.Name : value.ToString();
        }
        catch
        {
            return string.Empty;
        }
    }

    public static T ParseEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

}
