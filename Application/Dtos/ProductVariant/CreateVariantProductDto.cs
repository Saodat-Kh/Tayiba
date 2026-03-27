namespace Application.Dtos.ProductVariant;

public class CreateVariantProductDto
{
    public int?  ProductId { get; set; }
    public int? ItemProductId { get; set; }
    public string Size { get; set; }
    public string Color {get; set;}
}