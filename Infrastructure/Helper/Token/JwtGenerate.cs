using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Helper;

public class JwtGenerate(
    UserManager<AppUser> userManager,
    IConfiguration config)
{
    public async Task<string> GenerateJwtToken(AppUser appUser)
    {
        var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
        var securityKey = new SymmetricSecurityKey(key);
        var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Name, appUser.UserName),
            new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
            new Claim(JwtRegisteredClaimNames.NameId, appUser.Id.ToString())
        };

        var roles = await userManager.GetRolesAsync(appUser);
        claims.AddRange(roles.Select(role=> new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creadentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}