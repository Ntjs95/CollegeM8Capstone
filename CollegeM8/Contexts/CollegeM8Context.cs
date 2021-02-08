using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CollegeM8
{
    public class CollegeM8Context : DbContext
    {

        public CollegeM8Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } // Table
        public DbSet<Event> Events { get; set; } // Table
        public DbSet<Login> Logins { get; set; } // Table
    }
}
