using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Sleep
    {
        public static string TITLE_START = "SLEEP";
        [Key]
        public string UserId { get; set; }
        public float HoursWeekday { get; set; }
        public float HoursWeekend { get; set; }
        public DateTime WakeTimeWeekday { get; set; }
        public DateTime WakeTimeWeekend { get; set; }

        public User User { get; set; }

    }
}
