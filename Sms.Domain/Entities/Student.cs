using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Student:BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        //[Required(ErrorMessage = "Lastname is Required")]
        public string Lastname { get; set; }

        //[Required(ErrorMessage = "RollNo is Required")]
        //public int RollNoId { get; set; }

        //public string UserName { get; set; }

        //[Required(ErrorMessage = "Email Address is Required")]
        //public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        [StringLength(1024)]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [StringLength(20)]
        //[Required(ErrorMessage = "MobileNumber is Required")]
        public string Contact { get; set; }

        //[StringLength(20)]
        //public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int Age { get; set; }

        //public int EmergencyContact { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Picture { get; set; }

        public Transportation Transportation { get; set; }

    }
}
