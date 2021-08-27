using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Models
{
    public class Employees : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateEmployeed { get; set; }
    }
}
