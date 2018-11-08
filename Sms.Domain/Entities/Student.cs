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
        public string Lastname { get; set; }

        public int RollNoId { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        [StringLength(1024)]
        public string Address { get; set; }

        [StringLength(20)]
        public string MobileNumber { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int Age { get; set; }

        public int EmergencyContact { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ClassId { get; set; }

        public string Picture { get; set; }
    }
}
