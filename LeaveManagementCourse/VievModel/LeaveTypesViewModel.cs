using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.VievModel
{
    public class LeaveTypesVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Date created")]
        public DateTime? DateCreated { get; set; } // "?" means that the value is nullable
    }
}
