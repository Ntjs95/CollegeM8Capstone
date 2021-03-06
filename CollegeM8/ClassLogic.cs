﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ClassLogic: IClass
    {
        CollegeM8Context _db;

        public ClassLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Class CreateClass(Class _class)
        {
            _class.ClassId = Guid.NewGuid().ToString();
            _db.Classes.Add(_class);
            _db.SaveChanges();
            Class returnClass = GetClass(_class.ClassId);
            Schedule.UpdateSchedule(_db, _class.TermId).ConfigureAwait(false);
            return returnClass;
        }

        public bool DeleteClass(string id)
        {
            Assignment[] assignments = _db.Assignments.Where(a => a.ClassId == id).ToArray();
            if (assignments.Length > 0)
            {
                _db.Assignments.RemoveRange(assignments);
            }
            Exam[] exams = _db.Exams.Where(e => e.ClassId == id).ToArray();
            if (exams.Length > 0)
            {
                _db.Exams.RemoveRange(exams);
            }
            _db.Classes.Remove(_db.Classes.Find(id));
            _db.SaveChanges();
            return true;
        }

        public Class GetClass(string id)
        {
            return _db.Classes.AsNoTracking().FirstOrDefault(c => c.ClassId == id) ?? throw new ServiceException("Class not found");
        }

        public Class[] GetClassByUser(string userId)
        {
            Class[] classes = _db.Classes.AsNoTracking().Where(c => c.UserId == userId).ToArray();
            if(classes != null && classes.Length > 0)
            {
                return classes;
            }
            throw new ServiceException("Could not find classes");
        }

        public Class UpdateClass(Class newClass)
        {
            Class returnClass;
            Class oldClass = _db.Classes.FirstOrDefault(c => c.ClassId == newClass.ClassId);
            if(oldClass == null)
            {
                throw new ServiceException("Class not found");
            }
            else
            {
                oldClass.CourseCode = newClass.CourseCode;
                oldClass.ClassName = newClass.ClassName;
                oldClass.StartTime = newClass.StartTime;
                oldClass.EndTime = newClass.EndTime;
                oldClass.Monday = newClass.Monday;
                oldClass.Tuesday = newClass.Tuesday;
                oldClass.Wednesday = newClass.Wednesday;
                oldClass.Thursday = newClass.Thursday;
                oldClass.Friday = newClass.Friday;
                oldClass.Saturday = newClass.Saturday;
                oldClass.Sunday = newClass.Sunday;
                _db.Classes.Update(oldClass);
                _db.SaveChanges();
                returnClass = GetClass(newClass.ClassId);
                Schedule.UpdateSchedule(_db, oldClass.TermId).ConfigureAwait(false);
            }
            return returnClass;
        }
    }
}
