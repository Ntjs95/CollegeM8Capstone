using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
