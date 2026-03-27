using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Review;

public class CreateReviewDto
{
    [Required]
    public string UserName { get; set; }
    
    public int Rating { get; set; }
    [StringLength(300),MinLength(5)]
    public string Description { get; set; }
    public int ProductId { get; set; }

}