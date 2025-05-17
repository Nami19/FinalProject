using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class Educationalbackground
    {
       
        public int Id { get; set; } 
        public string ElementarySchool { get; set; } = string.Empty;
        public int ElementaryYearAttended { get; set; }

        public String HighSchool { get; set; } = String.Empty;
        public int HighSchoolYearAttended { get; set; }

        public String CollegeSchool { get; set; } = String.Empty;
        public int CollegeYearAttended2 { get; set; }
        public string DegreeReceived { get; set; } = string.Empty;

        public string SpecialSkills { get; set; } =string.Empty;
        public string Others { get; set; } = string.Empty;

        public Employee? Employee { get; set; } 
    }
}