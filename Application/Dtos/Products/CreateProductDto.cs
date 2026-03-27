using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Product;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public decimal Price { get; set; }
}