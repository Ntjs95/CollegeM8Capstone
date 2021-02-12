using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Assignment
    {
        [Key]
        public string AssignmentId { get; set; }
        public string UserId { get; set; }
        public string TermId { get; set; }
        public string ClassId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
        public int GradeWeight { get; set; } // 1-100
        public float HoursToComplete { get; set; }
        private float HoursCompleted { get; set; }
    }
}
