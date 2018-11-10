using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class TeacherClasses:BaseEntity
    {
        public TeacherClasses()
        {
            Classes=new List<Classes>();
            Employee=new List<Employee>();
        }

        public int ClassId { get; set; }
        public List<Classes> Classes { get; set; }

        public int EmployeeId { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
