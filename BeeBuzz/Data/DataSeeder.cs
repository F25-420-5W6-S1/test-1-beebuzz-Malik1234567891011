using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BeeBuzz.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Add roles
            var roles = new[] { "Admin", "Default" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Add initial organization
            var org = new Organization
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Name = "Initial Organization"
            };

            if (!context.Organizations.Any(o => o.Id == org.Id))
            {
                context.Organizations.Add(org);
                context.SaveChanges();
            }

            // Add admin user
            var adminEmail = "admin@beebuzz.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    OrganizationId = org.Id
                };
                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
