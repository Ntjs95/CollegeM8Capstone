using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ExamLogic: IExam
    {
        CollegeM8Context _db;

        public ExamLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Exam CreateExam(Exam exam)
        {
            Exam[] exams = _db.Exams.AsNoTracking().Where(e => e.UserId == exam.UserId).ToArray();
            if(!Exam.AnyExamsOverlap(exam, exams))
            {
                exam.ExamId = Guid.NewGuid().ToString();
                _db.Exams.Add(exam);
                _db.SaveChanges();
            }
            throw new ServiceException("Exam times cannot overlap.");
        }

        public bool DeleteExam(string id)
        {
            _db.Exams.Remove(_db.Exams.Find(id));
            _db.SaveChanges();
            return true;
        }

        public Exam GetExam(string id)
        {
            return _db.Exams.AsNoTracking().FirstOrDefault(e => e.ExamId == id) ?? throw new ServiceException("Could not find exam");
        }

        public Exam[] GetExamsByUser(string userId)
        {
            Exam[] exams = _db.Exams.AsNoTracking().Where(e => e.UserId == userId).ToArray();
            if(exams != null && exams.Length > 0)
            {
                return exams;
            }
            throw new ServiceException("Could not find exams");
        }

        public Exam UpdateExam(Exam exam)
        {
            Exam oldExam = _db.Exams.FirstOrDefault(e => e.ExamId == exam.ExamId);
            if(oldExam == null)
            {
                throw new ServiceException("Exam not found.");
            }
            else
            {
                oldExam.TermId = exam.TermId;
                oldExam.ClassId = exam.ClassId;
                oldExam.StartTime = exam.StartTime;
                oldExam.EndTime = exam.EndTime;
                _db.Exams.Update(oldExam);
                _db.SaveChanges();
            }
            return GetExam(exam.ExamId);
        }
    }
}
