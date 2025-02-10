using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLib.Context
{
    public class AppDbContextInitializer
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
                var admin = new IdentityUser
                {
                    UserName = "adminSaba@example.com",
                    Email = "adminSaba@example.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin123!"); // Default password
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}