using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[MF]$", ErrorMessage = "Please enter M' for MALE or F' for FEMALE.")]
        public char Sex { get; set; } = ' ';
        public DateTime BirthDate { get; set; }
        public DateTime HiredDate { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string CivilStatus { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string PresentAddress { get; set; } = string.Empty;
        public string PermanentAddress { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string BloodType { get; set; }
        public string FathersName { get; set; } = string.Empty;
        public string FathersOccupation { get; set; } = string.Empty;
        public string MothersName { get; set; } = string.Empty;
        public string MothersOccupation { get; set; } = string.Empty;
        public string PersonContactedInCaseOfEmergency { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public int ContactNumber { get; set; }
        public string PositionDesired  { get; set; }
        public DateTime DateApplied { get; set; }

        public Employee Employee { get; set; }

    }
}