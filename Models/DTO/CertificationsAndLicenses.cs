using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class CertificationsAndLisencesDto
    {
        public CertificationsLicensces CertificationsAndlicenses { get; set; }
        public List<Employee> Employees { get; set; }
    }

}