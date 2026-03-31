using Application.Dtos.ProductVariant;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductVariantController(IProductVariantService service) : Controller
{
    [HttpPost]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> CreateProductVariant([FromBody] CreateVariantProductDto productVariant)
    {
        var res = await service.CreateProductVariant(productVariant);
        return StatusCode(res.StatusCode, res);
    }
}