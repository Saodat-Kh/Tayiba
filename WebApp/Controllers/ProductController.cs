using Application.Dtos.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : Controller 
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        var res = await service.CreateProduct(createProductDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var res = await service.GetAllProducts();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var res = await service.UpdateProduct(updateProductDto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var res = await service.DeleteProduct(id);
        return StatusCode(res.StatusCode, res);
    }
}