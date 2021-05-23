using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiOgrenBeta.Models
{
    public class Context:DbContext
    {
       public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<TestClass> TestClasses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
    }
}
//server = DESKTOP-SL3JNSJ\\SQLEXPRESS ;  database=DbCoreBiOgren2;integrated security = true