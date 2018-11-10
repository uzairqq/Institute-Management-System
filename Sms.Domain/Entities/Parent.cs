using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Parent:BaseEntity
    {
        public Parent()
        {
            Student = new List<Student>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public string RelationShip { get; set; }
        public string Email { get; set; }
            
        public int StudentId { get; set; }
        public List<Student> Student { get; set; }
    }
}
