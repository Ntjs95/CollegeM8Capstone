using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Term
    {
        [Key]
        public string TermId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        internal static HashSet<string> GenerateIdVault(Term[] terms)
        {
            if(terms == null || terms.Length == 0)
            {
                return null;
            }
            HashSet<string> vault = new HashSet<string>();
            foreach (Term term in terms)
            {
                vault.Add(term.TermId);
            }
            return vault;
        }

        internal static bool AnyTermsOverlap(Term newTerm, Term[] existingTerms)
        {
            bool anyOverlap = false;
            foreach (Term existingTerm in existingTerms)
            { 
                anyOverlap |= DateHelper.AnyDatesIntersect(newTerm.StartDate, newTerm.EndDate, existingTerm.StartDate, existingTerm.EndDate);
            }
            return anyOverlap;
        }
    }
}
