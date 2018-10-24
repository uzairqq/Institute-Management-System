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
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Email { get; set; }
    }
}
