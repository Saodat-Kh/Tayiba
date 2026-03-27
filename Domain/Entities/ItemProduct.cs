

namespace Domain.Entities;

public class ItemProduct : BaseEntities
{
    public int Quantity { get; set; }
    public List<string> Photo { get; set; } = new List<string>();
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public List<ProductVariant>?  ProductVariants { get; set; }
}