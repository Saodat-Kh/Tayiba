using Application.Dtos.Category;
using Application.Interfaces;
using Infrastructure.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService service) : Controller
{
    [HttpPost]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        var res = await service.CreateCategory(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var res = await service.GetAllCategories();
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut("id")]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto dto)
    {
        var res = await service.UpdateCategory(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var res = await service.DeleteCategory(id);
        return StatusCode(res.StatusCode, res);
    }
    
}