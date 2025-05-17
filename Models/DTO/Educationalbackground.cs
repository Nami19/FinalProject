using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class EducationalbackgroundDto
    {
        public Educationalbackground Educationalbackground { get; set; }
        public List<Employee> Employees { get; set; }

    }
}