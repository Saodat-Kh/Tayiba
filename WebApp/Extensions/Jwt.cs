using Domain.Entities;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Extensions;

public static class Jwt
{
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddScoped<JwtGenerate>(o=> new JwtGenerate(
           o.GetRequiredService<UserManager<AppUser>>(),
           configuration.GetSection("Jwt:Key")));
    }
}