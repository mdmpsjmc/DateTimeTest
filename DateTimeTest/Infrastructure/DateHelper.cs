using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Infrastructure
{
    public class DateHelper
    {
        public static double DateTimeToUnixTimestamp(DateTime? dateTime)
        {
            if (dateTime == null) return 0;
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime.Value) -
                     new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime? UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            Nullable<DateTime> dt = dtDateTime;
            return dt;
            ;
        }
    }
}
