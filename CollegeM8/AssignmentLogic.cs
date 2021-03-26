using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class AssignmentLogic : IAssignment
    {
        CollegeM8Context _db;

        public AssignmentLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Assignment CreateAssignment(Assignment assignment)
        {
            if(assignment.ReleaseDate > assignment.DueDate)
            {
                throw new ServiceException("Due date must be after release date.");
            }
            assignment.AssignmentId = Guid.NewGuid().ToString();
            string termId = _db.Classes.FirstOrDefault(c => c.ClassId == assignment.ClassId).TermId;
            assignment.TermId = termId;
            _db.Assignments.Add(assignment);
            _db.SaveChanges();
            return GetAssignment(assignment.AssignmentId);
        }

        public bool DeleteAssignment(string id)
        {
            _db.Assignments.Remove(_db.Assignments.Find(id));
            _db.SaveChanges();
            return true;
        }

        public Assignment GetAssignment(string id)
        {
            return _db.Assignments.AsNoTracking().FirstOrDefault(a => a.AssignmentId == id) ?? throw new ServiceException("Could not find assignment");
        }

        public Assignment[] GetAssignmentByUser(string userId)
        {
            Assignment[] assignments = _db.Assignments.AsNoTracking().Where(a => a.UserId == userId).ToArray();
            if(assignments != null && assignments.Length > 0)
            {
                return assignments;
            }
            throw new ServiceException("Couuld not find assignments.");

        }

        public Assignment UpdateAssignment(Assignment assignment)
        {
            Assignment oldAssignment = _db.Assignments.FirstOrDefault(a => a.AssignmentId == assignment.AssignmentId);
            if(assignment == null)
            {
                throw new ServiceException("Assignment not found");
            }else if (assignment.ReleaseDate > assignment.DueDate)
            {
                throw new ServiceException("Due date must be after release date.");
            }
            else
            {
                oldAssignment.ReleaseDate = assignment.ReleaseDate;
                oldAssignment.DueDate = assignment.DueDate;
                oldAssignment.GradeWeight = assignment.GradeWeight;
                oldAssignment.HoursToComplete = assignment.HoursToComplete;

                _db.Assignments.Update(oldAssignment);
                _db.SaveChanges();
                return GetAssignment(assignment.AssignmentId);
            }
        }
    }
}
