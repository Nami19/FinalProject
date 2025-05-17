using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class WorkInfoDto
    {
        public WorkInfo WorkInfo { get; set; }

       public string EmploymentStatus { get; set; }
        public string DateHired {get; set;}
        public string Position { get; set; }
        public string Reportorial { get; set; }
        public List<Employee> Employees { get; set; }
    }
}