using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class DualDates
    {
        public DateTime Start;
        public DateTime End;

        public double LengthHours()
        {
            return End.Subtract(Start).TotalHours;
        }
    }
}
