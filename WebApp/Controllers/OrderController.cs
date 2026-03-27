using Application.Dtos.Order;
using Application.Dtos.OrderForAdmin;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service) : Controller
{

    [HttpPost]
    public  async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
    {
        var res = await service.CreateOrder(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    
    public async Task<IActionResult> GetOrders()
    {
        var res = await service.GetAllOrders();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto dto)
    {
        var res = await service.UpdateOrder(dto);
        return StatusCode(res.StatusCode, res);
    }
}