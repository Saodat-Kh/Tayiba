using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.OrderRepository;

public class OrderRepository(ApplicationDataContext context) : IOrderRepository
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
        var res = await context.Orders.Include(o => o.ProductVariant)
            .ThenInclude(p=> p.Product).ThenInclude(i=> i.ItemProducts).ToListAsync();
        return res;
    }
    
    public async Task<int> UpdateOrder(Order order)
    {
        context.Orders.Update(order);
        var res = await context.SaveChangesAsync();
        return res;
    }

    public async Task<Order> GetOrderById(int Id)
    {
        return await context.Orders.FirstOrDefaultAsync(x=> x.Id == Id );
    }
}