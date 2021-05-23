using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiOgrenBeta.Models
{
    public class Mentor
    {
        [Required]
        public int MentorID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MentorName { get; set; }
        [Required]
        public string MentorSurname { get; set; }
        [Required]
        public string MentorDepartment { get; set; }
        public int MentorCourseQuantity { get; set; }

        public List<Course> Courses { get; set; }
    }
}
