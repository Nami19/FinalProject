using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class TrainingInfo
    {
        public int Id { get; set; }
        public string RelevantTrainings { get; set; } = string.Empty;
        public DateTime TrainingDate {get; set;}

        public Employee? Employee { get; set; }
    }
}
