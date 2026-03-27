namespace Domain.Entities;

public class ProductVariant : BaseEntities
{
    public int?  ProductId { get; set; }
    public int? ItemProductId { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public Product? Product { get; set; }
    public ItemProduct? ItemProduct { get; set; }
}