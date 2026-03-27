using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.OrderRepository;

public class OrderRepository(ApplicationDataContext context, IMemoryCache cache) : IOrderRepository
{
    private readonly string key = "order";
    public async Task<int> AddOrder(Order order)
    {
        context.Orders.Add(order);
        var res =  await context.SaveChangesAsync();
        return res;
    }

    public async Task<List<Order>> GetOrders()
    {
        var res = await context.Orders.Include(o=> o.Product).ToListAsync();
        return res;
    }
    
    public async Task<int> UpdateOrder(Order order)
    {
        context.Orders.Update(order);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<Order> GetOrderById(int Id)
    {
        return await context.Orders.FirstOrDefaultAsync(x=> x.Id == Id);
    }
}