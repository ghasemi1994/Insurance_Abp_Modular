
using System.Globalization;

namespace Application.Utility.Extensions;

public static class DateExtension
{
    public static string ToPersionDate(this DateTime dateTime)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        return persianCalendar.GetYear(dateTime) + "/" +
               persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
               persianCalendar.GetDayOfMonth(dateTime).ToString("00");
    }

    public static string ToPersionDate(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
            return "";

        PersianCalendar persianCalendar = new PersianCalendar();
        return persianCalendar.GetYear(dateTime.Value) + "/" +
               persianCalendar.GetMonth(dateTime.Value).ToString("00") + "/" +
               persianCalendar.GetDayOfMonth(dateTime.Value).ToString("00");
    }


    public static string ToPersionDateWithTime(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
            return null;

        PersianCalendar persianCalendar = new PersianCalendar();

        return persianCalendar.GetYear(dateTime.Value)
            + "/" + persianCalendar.GetMonth(dateTime.Value).ToString("00")
            + "/" + persianCalendar.GetDayOfMonth(dateTime.Value).ToString("00")

            + " " + persianCalendar.GetHour(dateTime.Value).ToString("00")
            + ":" + persianCalendar.GetMinute(dateTime.Value).ToString("00")
            + ":" + persianCalendar.GetSecond(dateTime.Value).ToString("00")
            ;
    }

    public static string ToPersionDateWithTime(this DateTime dateTime)
    {        
        PersianCalendar persianCalendar = new PersianCalendar();

        return persianCalendar.GetYear(dateTime) 
            + "/" + persianCalendar.GetMonth(dateTime).ToString("00")
            + "/" + persianCalendar.GetDayOfMonth(dateTime).ToString("00") 

            + " " + persianCalendar.GetHour(dateTime).ToString("00")
            + ":" + persianCalendar.GetMinute(dateTime).ToString("00")
            + ":" + persianCalendar.GetSecond(dateTime).ToString("00")
            ;
    }

    /// <summary>
    /// shamsi date to miladi date
    /// </summary>
    /// <param name="dateTime">Shamsi String Date</param>
    /// <returns></returns>
    public static DateTime? ToMiladiDate(this string dateTime)
    {      
        if (string.IsNullOrEmpty(dateTime))
            return null;

        int day = Convert.ToInt32(dateTime.Split('/')[2]);
        int month = Convert.ToInt32(dateTime.Split('/')[1]);
        int year = Convert.ToInt32(dateTime.Split('/')[0]);
        var persianCalendar = new PersianCalendar();
        var date = persianCalendar.ToDateTime(year, month, day, 23, 0, 0, 0);

        return date;
    }
   

    /// <summary>
    /// shamsi date to miladi date with time YYYY/MM/dd 00:00:00
    /// </summary>
    /// <param name="dateTime">Shamsi String Date with time 00:00:00</param>
    /// <returns></returns>
    public static DateTime? ToMiladiDateWithTime(this string dateTime)
    {
        if (string.IsNullOrEmpty(dateTime))
            return null;

        string[] seprateDateAndTime = dateTime.Split(' ');

        if (seprateDateAndTime.Length != 2)
            throw new Exception("date and time are not valid");

        string[] seprateOnlyTime = seprateDateAndTime[1].Split(":");

        if (seprateOnlyTime.Length != 3)
            throw new Exception("date and time are not valid");

        int day = Convert.ToInt32(seprateDateAndTime[0].Split('/')[2]);
        int month = Convert.ToInt32(seprateDateAndTime[0].Split('/')[1]);
        int year = Convert.ToInt32(seprateDateAndTime[0].Split('/')[0]);

        var persianCalendar = new PersianCalendar();
        var date = persianCalendar.ToDateTime(year, month, day,

          seprateOnlyTime[0] != null ? Convert.ToInt32(seprateOnlyTime[0]) : 0,

          seprateOnlyTime[1] != null ? Convert.ToInt32(seprateOnlyTime[1]) : 0,

          seprateOnlyTime[2] != null ? Convert.ToInt32(seprateOnlyTime[2]) : 0,

            0);

        return date;

    }

    public static string GetPersianDayOfWeekName(this DateTime dateTime)
    {
        DayOfWeek dayOfWeek = dateTime.DayOfWeek;

        switch (dayOfWeek)
        {
            case DayOfWeek.Sunday:
                return "یکشنبه";
            case DayOfWeek.Monday:
                return "دوشنبه";
            case DayOfWeek.Tuesday:
                return "سه‌ شنبه";
            case DayOfWeek.Wednesday:
                return "چهارشنبه";
            case DayOfWeek.Thursday:
                return "پنجشنبه";
            case DayOfWeek.Friday:
                return "جمعه";
            case DayOfWeek.Saturday:
                return "شنبه";
            default:
                return "";
        }
    }

    public static int GetDayOfMonthNumber(this DateTime dateTime)
    {
        string date = dateTime.ToPersionDate();

        string[] day = date.Split('/');

        return day[2].ToInt32();
    }
}
