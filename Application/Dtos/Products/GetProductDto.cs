using Application.Dtos.ItemProduct;

namespace Application.Dtos.Product;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int CategoryId { get; set; }

    public List<GetItemProductDto> Items { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}