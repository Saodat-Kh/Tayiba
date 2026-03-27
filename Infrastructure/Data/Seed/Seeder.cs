using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;

public class Seeder(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager)
{
    public async Task<bool> SeedUser()
    {
        var existing = await userManager.FindByNameAsync("admin");
        if(existing != null) return false;

        var user = new AppUser()
        {
            UserName = "admin",
            Email = "admin@mail.com",
            Address = "Firdavsi",
            FullName = "Admin",
        };

        var result = await userManager.CreateAsync(user, "Qwerty123");
        if(!result.Succeeded) return false;
        await userManager.AddToRoleAsync(user, Roles.Admin);
        return true;
    }

    public async Task<bool> SeedRole()
    {
        var newRole = new List<IdentityRole<int>>()
        {
            new IdentityRole<int>(Roles.Admin),
            new IdentityRole<int>(Roles.User)
        };
        var roles = await roleManager.Roles.ToListAsync();

        foreach (var role in newRole)
        {
            if (roles.Exists(r => r.Name == role.Name))
            {
                continue;
            }

            await roleManager.CreateAsync(role);
        }
        return true;
    }
}

public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
}