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
    }
}
