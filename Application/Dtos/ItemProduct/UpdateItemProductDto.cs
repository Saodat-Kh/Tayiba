using Microsoft.AspNetCore.Http;

namespace Application.Dtos.ItemProduct;

public class UpdateItemProductDto
{
    public int Id { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public  List<IFormFile>? Photo { get; set; }
}