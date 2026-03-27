using Application.Dtos.ProductVariant;

namespace Application.Dtos.ItemProduct;

public class GetItemProductDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public  List<string> Photo { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<GetProductVariantDto>  Variants { get; set; }
}