using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Domain.Entities;

using Infrastructure.Data;
using Infrastructure.Helper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Extensions;

public static class RegisterAuthService
{
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
         System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        services
            .AddIdentity<AppUser, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDataContext>()
            .AddDefaultTokenProviders();
        services.AddAuthentication(options =>
            {
                // options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    
                    RoleClaimType = "role",
                    NameClaimType = "unique_name",
                    ClockSkew = TimeSpan.Zero
                };
            });

        // services.AddAuthentication();
        services.AddScoped<JwtGenerate>();
        services.AddScoped<IAuthService>(op => new AuthService(
            op.GetRequiredService<UserManager<AppUser>>(),
            op.GetRequiredService<JwtGenerate>()));
    }

}