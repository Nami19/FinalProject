using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class WorkInfo
    {
        public int Id { get; set; }
        public string Employmentstatus{ get; set; } = string.Empty;
        public DateTime DateHired { get; set; } 
        public string Position { get; set; } = string.Empty;
        public string Reportorial { get; set; } = string.Empty;

        public Employee? Employee { get; set; }
    }
}