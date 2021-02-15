using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface IAssignment
    {
        public Assignment GetAssignment(string id);
        public Assignment[] GetAssignmentByUser(string userId);
        public Assignment CreateAssignment(Assignment assignment);
        public Assignment UpdateAssignment(Assignment assignment);
        public bool DeleteAssignment(string id);
    }
}
