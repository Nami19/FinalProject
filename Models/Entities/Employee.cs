using JwtAuthDemo.Models.Info;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace JwtAuthDemo.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName{ get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[MF]$",ErrorMessage = "Please enter M' for MALE or F' for FEMALE.")]
        public char Sex { get; set; } = ' ';

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CivilStatus { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;



        public virtual ICollection<PersonalInformation>? PersonalInformation { get; set; }
        public virtual ICollection<Educationalbackground>? Educationalbackround { get; set; }
        public virtual ICollection<CertificationsLicensces>? CertificationsLicenses { get; set; }
        public virtual ICollection<GovernmentInfo>? GovernmentInfo { get; set; }
        public virtual ICollection<TrainingInfo>? TrainingInfo { get; set; }
        public virtual ICollection<WorkExperience>? WorkExerience { get; set; }
        public virtual ICollection<WorkInfo>? WorkInfo { get; set; }
    }
}