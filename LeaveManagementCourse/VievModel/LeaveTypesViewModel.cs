﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.VievModel
{
    public class DetailsLeaveTypesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypesVM
    {
        [Required]
        public string Name { get; set; }
    }
}
