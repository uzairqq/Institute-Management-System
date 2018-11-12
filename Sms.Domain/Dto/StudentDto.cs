using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sms.Domain.Entities;

namespace Sms.Domain.Dto
{
   public class StudentDto:BaseEntity
    {
       
        public string Name { get; set; }

        public string Lastname { get; set; }

        public int RollNoId { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Gender { get; set; }

      
        public string Address { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int EmergencyContact { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Picture { get; set; }

        //public Transportation Transportation { get; set; }
    }
}
