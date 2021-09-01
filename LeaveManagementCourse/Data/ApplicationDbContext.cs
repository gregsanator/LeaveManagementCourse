using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementCourse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementCourse.VievModel;

namespace LeaveManagementCourse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<LeaveTypes> LeaveTypes { get; set; }
        public DbSet<LeaveAllocations> LeaveAllocations { get; set; }
        public DbSet<LeaveHistories> LeaveHistories { get; set; }
        public DbSet<LeaveManagementCourse.VievModel.LeaveTypesVM> DetailsLeaveTypesVM { get; set; }
    }
}
