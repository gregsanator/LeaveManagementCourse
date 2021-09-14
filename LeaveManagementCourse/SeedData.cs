using LeaveManagementCourse.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager); // this needs to be called first so that we can create the Administrator and User roles
            SeedUsers(userManager); // when we giving the role to the user the role needs to exist first that is why we calling SeedRoles first
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager) // we are creating an admin user
        {
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }


        public static void SeedRoles(RoleManager<IdentityRole> roleManager) // This method creates new Roles
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result) // Check if Admin Role exists and if not
            {
                var role = new IdentityRole // create new identity role with the name Administrator(AspNetRoles table)
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result; // creating the role
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
