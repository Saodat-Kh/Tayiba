using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product : BaseEntities
{
    [Required]
    public required string Name { get; set; }
    [Required]
    [StringLength(100,MinimumLength = 25)]
    public string  Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    
    //navigation
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public List<ItemProduct>? ItemProducts { get; set; }
    
    public List<Review>? Reviews { get; set; }
    public List<Order>? Orders { get; set; }
}