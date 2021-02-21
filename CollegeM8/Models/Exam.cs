using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Exam
    {
        [Key]
        public string ExamId { get; set; }
        public string ClassId { get; set; }
        public string TermId { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public static string TITLE_START = "EXAM: ";

        internal static bool AnyExamsOverlap(Exam exam, Exam[] exams)
        {
            bool anyOverlap = false;
            foreach (Exam existingExam in exams)
            {
                anyOverlap |= DateHelper.AnyDatesIntersect(exam.StartTime, exam.EndTime, existingExam.StartTime, existingExam.EndTime);
            }
            return anyOverlap;
        }
    }
}
