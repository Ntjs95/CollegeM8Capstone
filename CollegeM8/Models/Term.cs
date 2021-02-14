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

        internal static HashSet<string> GenerateIdVault(List<Term> terms)
        {
            if(terms == null || terms.Count == 0)
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

    }
}
