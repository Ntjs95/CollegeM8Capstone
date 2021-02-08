using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Event
    {
        [Key]
        public string EventId { get; set; }
        public string UserId { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursToCompleteTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursCompletedSoFar { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
