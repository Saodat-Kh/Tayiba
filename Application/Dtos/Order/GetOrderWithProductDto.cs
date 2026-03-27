using Application.Dtos.Product;
using Application.Dtos.User;
using Domain.Enum;

namespace Application.Dtos.Order;

public class GetOrderWithProductDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public List<GetProductDto>  Products { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
    public OrderStatus Status { get; set; }
}