using Domain.Enum;

namespace Application.Dtos.Order;

public class GetOrderWihProductDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }
}