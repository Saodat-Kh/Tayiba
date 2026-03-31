using Application.Dtos.Financy;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DashboardController(IDashboardService service) : Controller
{
    [HttpGet("profit")]
    public async Task<IActionResult> GetProfit()
    {
        var res = await service.GetFinancies();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("order_status")]
    public async Task<IActionResult> GetOrderStatus()
    {
        var res = await service.GetOrderStatus();
        return StatusCode(res.StatusCode, res);
    }
}