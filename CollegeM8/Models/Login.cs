using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Login
    {
        [Key]
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreatedDate { get; set; }
    }
}
