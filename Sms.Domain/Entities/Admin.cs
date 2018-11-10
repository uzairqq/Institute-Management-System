using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Admin:BaseEntity
    {
        public Admin()
        {
            Students=new List<Student>();
        }
        public string Name { get; set; }
        public string LastName { get; set; }

        public List<Student> Students { get; set; }
    }
}
