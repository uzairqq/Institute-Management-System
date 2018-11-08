using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Attendance:BaseEntity
    {
        public string Status { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ClassId { get; set; }
        //public Class Class { get; set; }

        public int AttendacenTypeId { get; set; }
        public AttendanceType AttendanceType { get; set; }
    }
}
