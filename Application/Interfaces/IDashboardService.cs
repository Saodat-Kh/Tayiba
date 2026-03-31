using Application.Dtos.Financy;
using Application.Dtos.Order;
using Application.Responses;

namespace Application.Interfaces;

public interface IDashboardService
{
    Task<Response<List<GetFinanceDto>>> GetFinancies();
    Task<Response<List<GetOrderWithProductDto>>> GetOrderStatus();

}