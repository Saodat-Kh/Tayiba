namespace Application.Dtos.Review;

public class GetReviewForUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    
}