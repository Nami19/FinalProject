using JwtAuthDemo.Models.Info;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models
{
    public class WorkExperienceDto
    {
        public WorkExperience WorkExperience { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
