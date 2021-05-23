using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiOgrenBeta.Models
{
    public class Course
    {
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int MentorID { get; set; }
        [Required]
        public string CourseDescription { get; set; }

        [Required]
        [DisplayName("Video Adı")]
        public string Video { get; set; }
        [NotMapped]
        [DisplayName("Video Yolu")]
        public IFormFile VideoURL { get; set; } 
     
        public virtual Mentor Mentor { get; set; }
    }
}
