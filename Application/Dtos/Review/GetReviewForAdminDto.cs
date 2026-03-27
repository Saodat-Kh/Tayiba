using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Application.Dtos.Review;

public class GetReviewForAdminDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public StatusReview Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
}

