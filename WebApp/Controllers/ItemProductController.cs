using Application.Dtos.ItemProduct;
using Application.Dtos.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ItemProductController(IItemProductService service) : Controller
{
    [HttpPost]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> CreateProduct([FromForm] CreateItemProductDto dto)
    {
        var res = await service.CreateItemProduct(dto);
        return StatusCode(res.StatusCode, res);
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var res = await service.GetAllItemProducts();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> UpdateProduct([FromForm] UpdateItemProductDto updateProductDto)
    {
        var res = await service.UpdateItemProduct(updateProductDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var res = await service.DeleteItemProduct(id);
        return StatusCode(res.StatusCode, res);
    }
    
}