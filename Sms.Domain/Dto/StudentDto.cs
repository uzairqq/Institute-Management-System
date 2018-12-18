using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sms.Domain.Entities;

namespace Sms.Domain.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        //public int RollNoId { get; set; }

        //public string UserName { get; set; }

        //public string EmailAddress { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        //public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Age { get; set; } //when selecting dob it will calculate the age (function)

        public int EmergencyContact { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Picture { get; set; }

        //public Transportation Transportation { get; set; }

       
    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
