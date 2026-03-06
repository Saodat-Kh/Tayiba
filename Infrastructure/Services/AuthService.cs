using System.Net;
using Application.Dtos.Auth;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class AuthService(UserManager<User> userManager, JwtGenerate jwtGenerate) : IAuthService
{
    public async Task<Response<string>> Login(LoginDto login)
    {
        var existingUser = await userManager.FindByNameAsync(login.UserName);
        if (existingUser == null)
            return new Response<string>(HttpStatusCode.BadRequest, "UserName or password is Incorrect");
        var result = await userManager.CheckPasswordAsync(existingUser, login.Password);
        if (!result)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "UserName or password is Incorrect");
        }

        var token = await jwtGenerate.GenerateJwtToken(existingUser);
        return new Response<string>(HttpStatusCode.OK,token);
    }
}