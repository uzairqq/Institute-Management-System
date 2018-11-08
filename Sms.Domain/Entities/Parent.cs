using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Parent:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
            
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
