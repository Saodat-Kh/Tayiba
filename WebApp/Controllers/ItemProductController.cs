using Application.Dtos.ItemProduct;
using Application.Dtos.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ItemProductController(IItemProductService service) : Controller
{
    [HttpPost]
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
    public async Task<IActionResult> UpdateProduct([FromForm] UpdateItemProductDto updateProductDto)
    {
        var res = await service.UpdateItemProduct(updateProductDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var res = await service.DeleteItemProduct(id);
        return StatusCode(res.StatusCode, res);
    }
    
}