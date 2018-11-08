using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Subject:BaseEntity
    {
        public string Name { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ClassId { get; set; }
        public Classes Classes { get; set; }
    }
}
