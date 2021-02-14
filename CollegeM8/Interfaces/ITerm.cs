using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface ITerm
    {
        public Term GetTerm(string id);
        public Term[] GetTermByUser(string userId);
        public Term CreateTerm(Term term);
        public Term UpdateTerm(Term term);
        public bool DeleteTerm(string id);
    }
}
