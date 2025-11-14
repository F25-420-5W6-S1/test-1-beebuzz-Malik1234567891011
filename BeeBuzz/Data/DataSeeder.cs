using System;
using System.Threading.Tasks;
using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeeBuzz.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Apply pending migrations
            await context.Database.MigrateAsync();
            //the migrations are broken im super annoyed im skippingit for now (nevermind i fixed kinda)
           // await context.Database.EnsureDeletedAsync();
            //await context.Database.EnsureCreatedAsync();

            const string adminRole = "Admin";
            const string defaultRole = "Default";

            // Roles
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (!await roleManager.RoleExistsAsync(defaultRole))
            {
                await roleManager.CreateAsync(new IdentityRole(defaultRole));
            }

            // Initial organization "0000-0000-0000-0000"
            const string initialOrgName = "0000-0000-0000-0000";
            var org = await context.Organizations
                .FirstOrDefaultAsync(o => o.Name == initialOrgName);

            if (org == null)
            {
                org = new Organization
                {
                    Id = Guid.NewGuid(),
                    Name = initialOrgName
                };
                context.Organizations.Add(org);
                await context.SaveChangesAsync();
            }

            // Admin user
            const string adminEmail = "admin@beebuzz.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    OrganizationId = org.Id
                };

                // Password matches your relaxed Identity options (min length 4)
                var result = await userManager.CreateAsync(adminUser, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                    await userManager.AddToRoleAsync(adminUser, defaultRole);
                }
                else
                {
                    // If you want, log or inspect result.Errors in debug
                }
            }
        }
    }
}
