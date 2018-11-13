using System;
using System.Collections.Generic;
using System.Text;
using Sms.Domain.Entities;

namespace Sms.Domain.Dto
{
   public class EmployeeDto:BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SubjectId { get; set; }
    }
}
