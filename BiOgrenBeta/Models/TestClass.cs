using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BiOgrenBeta.Models
{
    public class TestClass
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        public string VideoName { get; set; }
        public int CategoryID { get; set; }
        [Required]
        public string VideoPath { get; set; }
        [NotMapped]
        public IFormFile VideoURL { get; set; }
        public virtual CourseCategory Category { get; set; }
    }
}
