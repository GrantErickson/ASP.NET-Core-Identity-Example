using Microsoft.AspNetCore.Identity;

namespace AuthTest.Data
{
    public static class Roles
    {
        public const string Admin = "Admin";
        
        public static async Task Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Admin));
            }

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var user = new AppUser
                {
                    UserName = "admin@intellitect.com",
                    Email = "admin@intellitect.com",
                    EmailConfirmed = true,
                };
                var result = await userManager.CreateAsync(user, "P@ssw0rd!!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Admin);
                }
            }
        }
    }
}
