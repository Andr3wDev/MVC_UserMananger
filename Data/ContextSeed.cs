using Freelance.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelance.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(
                new IdentityRole(Enumerations.Roles.Admin.ToString()));
            await roleManager.CreateAsync(
                new IdentityRole(Enumerations.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(
                new IdentityRole(Enumerations.Roles.Basic.ToString()));
        }

        public static async Task SeedAdminUserAsync(
            UserManager<ApplicationUser> userManager)
        {
            // Admin User
            var adminUser = new ApplicationUser
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "Qwertyuiop1!");
                await userManager.AddToRoleAsync(
                    adminUser, Enumerations.Roles.Basic.ToString());
                await userManager.AddToRoleAsync(
                    adminUser, Enumerations.Roles.Moderator.ToString());
                await userManager.AddToRoleAsync(
                    adminUser, Enumerations.Roles.Admin.ToString());
            }
        }
    }
}
