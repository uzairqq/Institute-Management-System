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

        [StringLength(1024)]
        public string Address { get; set; }

        [StringLength(20)]
        public string MobileNumber { get; set; }

        [StringLength(20)]
        public string HomeNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int Age { get; set; }

        public int EmergencyContact { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
