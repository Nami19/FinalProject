using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class GovernmentInfo
    {
        public int Id { get; set; }
        public string SSS { get; set; } = string.Empty;
        public string PhilHealth { get; set; } = string.Empty;
        public string PagIbig { get; set; } = string.Empty;
        public string TinID { get; set; } = string.Empty;

        public Employee? Employee { get; set; }
    }
}
