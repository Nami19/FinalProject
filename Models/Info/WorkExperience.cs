using JwtAuthDemo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models.Info
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string PreviousCompanies { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public Employee? Employee { get; set; }
    }
}