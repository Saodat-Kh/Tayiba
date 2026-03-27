using Application.Dtos.Order;
using Application.Dtos.OrderForAdmin;
using Application.Responses;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<Response<string>> CreateOrder(CreateOrderDto dto);
    Task<Response<List<GetOrderWithProductDto>>> GetAllOrders();
    Task<Response<string>> UpdateOrder(UpdateOrderDto dto);
}