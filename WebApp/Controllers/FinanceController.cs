using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FinanceController(IFinanceService service) : Controller
{
    [HttpGet]
  
    public async Task<IActionResult> GetFinancy()
    {
        var res = await service.GetFinancy();
        return StatusCode(res.StatusCode, res);
    }
}