using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class TermLogic: ITerm
    {
        CollegeM8Context _db;

        public TermLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Term CreateTerm(Term term)
        {
            Term[] terms = _db.Term.AsNoTracking().Where(t => t.UserId == term.UserId).ToArray();
            if (!Term.AnyTermsOverlap(term, terms))
            {
                term.TermId = Guid.NewGuid().ToString();
                _db.Term.Add(term);
                _db.SaveChanges();
                return GetTerm(term.TermId);
            }
            throw new ServiceException("Terms cannot overlap");
        }

        public bool DeleteTerm(string id)
        {
            _db.Term.Remove(_db.Term.Find(id));
            _db.SaveChanges();
            return true;
        }

        public Term GetTerm(string id)
        {
            return _db.Term.AsNoTracking().FirstOrDefault(t => t.TermId == id) ?? throw new ServiceException("Could not find term.");
        }

        public Term[] GetTermByUser(string userId)
        {
            Term[] terms = _db.Term.AsNoTracking().Where(t => t.UserId == userId).ToArray();
            if (terms != null && terms.Length > 0)
            {
                return terms;
            }
            throw new ServiceException("Could not find terms");
        }

        public Term UpdateTerm(Term term)
        {
            Term oldTerm = _db.Term.FirstOrDefault(t => t.TermId == term.TermId);
            if(oldTerm == null)
            {
                throw new ServiceException("Term not found");
            }
            else
            {
                oldTerm.StartDate = term.StartDate;
                oldTerm.EndDate = term.EndDate;
                _db.Term.Update(oldTerm);
                _db.SaveChanges();
            }
            return GetTerm(term.TermId);
        }
    }
}
