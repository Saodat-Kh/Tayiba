using System.ComponentModel.DataAnnotations;
using Application.Dtos.ProductVariant;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.ItemProduct;

public class CreateItemProductDto
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public  List<IFormFile>? Photo { get; set; }
    [Required]
    public List<CreateVariantProductDto> VariantProducts { get; set; }
}