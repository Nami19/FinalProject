using JwtAuthDemo.Models.Entities;
using JwtAuthDemo.Models.Info;

namespace JwtAuthDemo.Models
{
    public class GovernmentInfoDto
    {
        public GovernmentInfo GovernmentInfo { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
