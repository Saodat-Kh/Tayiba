using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FinanceController(IFinancyService service) : Controller
{
    [HttpGet]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> GetFinancy(DateTime dateTo, DateTime dateFrom)
    {
        var res = await service.GetFinancy( dateTo,  dateFrom);
        return StatusCode(res.StatusCode, res);
    }
}