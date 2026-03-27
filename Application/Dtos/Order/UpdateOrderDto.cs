using Domain.Enum;

namespace Application.Dtos.Order;

public class UpdateOrderDto
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}