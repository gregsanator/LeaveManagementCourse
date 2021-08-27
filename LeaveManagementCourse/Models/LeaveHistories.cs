using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Models
{
    public class LeaveHistories
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employees RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; } // which employee is associated with this leave
        public DateTime StartDate { get; set; } // start day of leave
        public DateTime EndDate { get; set; } // ending day of leave
        [ForeignKey("LeaveTypeId")]
        public LeaveTypes LeaveType { get; set; } //Type of leave
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; } //when was the leave requested
        public DateTime DateActioned { get; set; } //when was Ok'd or denied
        public bool? Approved { get; set; } // ? means it can be null and prop tells us if it was OK'd or denied
        [ForeignKey("ApprovedById")]
        public Employees ApprovedBy { get; set; } //Who approved the leave
        public string ApprovedById { get; set; }
    }
}
