using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FinanceController(IFinancyService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetFinancy()
    {
        var res = await service.GetFinancy();
        return StatusCode(res.StatusCode, res);
    }
}