using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Class
    {
        [Key]
        public string ClassId { get; set; }
        public string TermId { get; set; }
        public string UserId { get; set; }
        public string CourseCode { get; set; }
        public string ClassName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public static string TITLE_START = "CLASS: ";

        internal bool IsSchoolDay(DayOfWeek dayOfWeek)
        {
            if (Monday && dayOfWeek == DayOfWeek.Monday) return true;
            if (Tuesday && dayOfWeek == DayOfWeek.Tuesday) return true;
            if (Wednesday && dayOfWeek == DayOfWeek.Wednesday) return true;
            if (Thursday && dayOfWeek == DayOfWeek.Thursday) return true;
            if (Friday && dayOfWeek == DayOfWeek.Friday) return true;
            if (Saturday && dayOfWeek == DayOfWeek.Saturday) return true;
            if (Sunday && dayOfWeek == DayOfWeek.Sunday) return true;
            return false;
        }

        internal static HashSet<string> GenerateIdVault(Class[] _class)
        {
            if (_class == null || _class.Length == 0)
            {
                return null;
            }
            HashSet<string> vault = new HashSet<string>();
            foreach (Class term in _class)
            {
                vault.Add(term.TermId);
            }
            return vault;
        }

    }
}
