using Application.Dtos.Review;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewController(IReviewService service) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto review)
    {
        var res =await service.CreateReview(review);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("ForAdmin")]
    public async Task<IActionResult> GetReviewsForAdmin()
    {
        var res = await service.GetAllReview();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("ForUser")]
    public async Task<IActionResult> GetReviewsForUser(int productId)
    {
        var res = await service.GetAllReviewForUser(productId);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, UpdateReviewDto dto)
    {
        var res = await service.UpdateReview(id, dto);
        return StatusCode(res.StatusCode, res);
    }
}