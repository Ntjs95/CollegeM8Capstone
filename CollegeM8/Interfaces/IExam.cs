using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface IExam
    {
        public Exam GetExam(string id);
        public Exam[] GetExamsByUser(string userId);
        public Exam CreateExam(Exam exam);
        public Exam UpdateExam(Exam exam);
        public bool DeleteExam(string id);
    }
}
