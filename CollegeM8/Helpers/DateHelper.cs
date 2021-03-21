using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    internal static class DateHelper
    {
        internal static bool AnyDatesIntersect(DateTime firstSpanStart, DateTime firstSpanEnd, DateTime secondSpanStart, DateTime secondSpanEnd)
        {
            bool endsBefore = secondSpanEnd < firstSpanStart;
            bool startsAfter = secondSpanStart > firstSpanEnd;
            return !(endsBefore || startsAfter); // English = "If it does not end before the span, or start after the span, it must exist during the span."
        }

        static internal DateTime CombineDateTime(DateTime date, DateTime time)
        {
            return new DateTime(year: date.Year, month: date.Month, day: date.Day, hour: time.Hour, minute: time.Minute, 0);
        }

        static internal bool IsSameDay(DateTime firstDate, DateTime secondDate)
        {
            return firstDate.Day == secondDate.Day && firstDate.Month == secondDate.Month && firstDate.Year == secondDate.Year;
        }
    }
}
