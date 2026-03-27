using Domain.Enum;

namespace Domain.Entities;

public class Order : BaseEntities
{
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public OrderStatus Status { get; set; }
    
    
    public int? UserId { get; set; }
    public AppUser? User { get; set; }
    public int? ProductVariantId { get; set; }
    public ProductVariant? ProductVariant { get; set; }
    public Product? Product { get; set; }
}