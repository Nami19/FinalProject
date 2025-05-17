using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class CertificationsLicensces
    {
        public int Id { get; set; }
        public string PRCLicense { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OtherCertification { get; set; } = string.Empty;


        public Employee? Employee { get; set; }

    }
}