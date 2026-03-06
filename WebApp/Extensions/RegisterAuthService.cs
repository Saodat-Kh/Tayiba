using Application.Interfaces;
using Domain.Entities;

using Infrastructure.Data;
using Infrastructure.Helper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Extensions;

public static class RegisterAuthService
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDataContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<JwtGenerate>();
        services.AddScoped<IAuthService>(op=> new AuthService(
            op.GetRequiredService<UserManager<User>>(),
            op.GetRequiredService<JwtGenerate>()));
        
    }
    
}