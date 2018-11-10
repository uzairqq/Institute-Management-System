using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class StudentClasses:BaseEntity
    {
        public StudentClasses()
        {
            Student=new List<Student>();
            Classes=new List<Classes>();
        }
        public int ClassId { get; set; }
        public List<Classes> Classes { get; set; }

        public int StudentId { get; set; }
        public List<Student> Student { get; set; }
    }
}
