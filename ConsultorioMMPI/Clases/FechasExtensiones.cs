using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultorioMMPI.Clases
{
    public static class FechasExtensiones
    {
        public static DateTime ToGregoriano(this double? fecha)
        {
            string jdeDate = int.Parse((fecha.HasValue ? fecha.Value : 0d).ToString()).ToString();
            string day = string.Empty;
            string year = string.Empty;

            if (jdeDate.Length == 5)
            {
                // 5 character string for pre-year 2000 dates, year is first 2 chars
                year = jdeDate.Substring(0, 2);
            }
            else if (jdeDate.Length == 6)
            {
                // 6 characters for post 2000 dates, take first three characters
                year = jdeDate.Substring(0, 3);
            }
            else
            {
                return new DateTime();
            }
            // take last three characters for day
            day = jdeDate.Substring(jdeDate.Length - 3, 3);
            // calculate gregorian date
            DateTime gregorianDate = DateTime.Parse("1 Jan 1900");
            gregorianDate = gregorianDate.AddYears(Convert.ToInt16(year));
            gregorianDate = gregorianDate.AddDays(Convert.ToInt16(day) - 1);
            return gregorianDate;
        }
        public static double? ToJulianDate(this DateTime date)
        {
            return (1000 * (date.Year - 1900) + date.DayOfYear);
        }
        public static int ToJulianHour(DateTime datFecha)
        {
            return Convert.ToInt32((datFecha.Hour).ToString() + (datFecha.Minute).ToString("00") + (datFecha.Second).ToString("00"));
        }
    }
}
