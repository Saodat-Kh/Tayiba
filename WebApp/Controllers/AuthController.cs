using Application.Dtos.Auth;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService service) : Controller
{
    [HttpPost]
   
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var res = await service.Login(dto);
        return StatusCode(res.StatusCode, res);
    }
}