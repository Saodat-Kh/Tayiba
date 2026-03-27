using Domain.Entities;

namespace Infrastructure.Repository.OrderRepository;

public interface IOrderRepository
{
    Task<int> AddOrder(Order order);
    Task<List<Order>> GetOrders();
    Task<int> UpdateOrder(Order order);
}