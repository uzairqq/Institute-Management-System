using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class StudentTeacher:BaseEntity
    {
        public StudentTeacher()
        {
            Employee=new List<Employee>();
            Student = new List<Student>();
        }

        public int EmployeeId { get; set; }
        public List<Employee> Employee { get; set; }

        public int StudentId { get; set; }
        public List<Student> Student { get; set; }
    }
}
