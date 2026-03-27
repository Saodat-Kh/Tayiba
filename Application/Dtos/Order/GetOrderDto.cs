using Application.Dtos.Product;
using Domain.Enum;

namespace Application.Dtos.Order;

public class GetOrderDto
{    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public OrderStatus Status { get; set; }
    public int Id { get; set; }
    public List<GetProductDto>  Products { get; set; }
    public DateTime CreatedAt { get; set; }
}