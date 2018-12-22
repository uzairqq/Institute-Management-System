using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.Web.ViewModels
{
    public class DashboardTotalEntitiesCount 
    {
       
        [Display(Name = "Total Visits")]
        public int TotalVisits { get; set; }=12543;

        [Display(Name = "Today's Visits")]
        public int TodaysVisits { get; set; } = 340;

        [Display(Name = "Total Students")]
        public int TotalStudents { get; set; } = 876;

        [Display(Name = "Total Teachers")]
        public int TotalTeachers { get; set; } = 54;

        [Display(Name = "Total Parents")]
        public int TotalParents { get; set; } = 89;

        [Display(Name = "Total Librarian")]
        public int Librarian { get; set; } = 11;

        [Display(Name = "Total Accountants")]
        public int Accountants { get; set; } = 9;

        [Display(Name = "All Enquiries")]
        public int AllEnquiries { get; set; } = 23;

        [Display(Name = "Total Visits")]
        public int AllMessages { get; set; } = 2;

        [Display(Name = "Attendance")]
        public int Attendance { get; set; } = 1;

        [Display(Name = "Total Classes")]
        public int TotalClasses { get; set; } = 15;
    }
}
