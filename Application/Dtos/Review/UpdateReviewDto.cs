using Domain.Enum;

namespace Application.Dtos.Review;

public class UpdateReviewDto
{
    public int Id { get; set; }
    public StatusReview Status { get; set; }

}