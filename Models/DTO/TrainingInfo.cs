using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class TrainingInfoDto
    {
        public TrainingInfo TrainingInfo { get; set; }
        public List<Employee> Employees { get; set; }
    }
}