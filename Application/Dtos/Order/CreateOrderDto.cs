namespace Application.Dtos.OrderForAdmin;

public class CreateOrderDto
{
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public int ProductVariantId { get; set; }
    
}