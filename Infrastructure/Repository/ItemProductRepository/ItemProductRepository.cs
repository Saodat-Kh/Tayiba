using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ItemProductRepository;

public class ItemProductRepository(ApplicationDataContext context) : IItemProductRepository
{
    public async Task<int> CreateItemProductAsync(ItemProduct item)
    {
        context.ItemProducts.Add(item);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateItemProductAsync(ItemProduct item)
    {
        context.ItemProducts.Update(item);
        return await context.SaveChangesAsync();
    }

    public async Task<ItemProduct> GetItemProductById(int id)
    => await  context.ItemProducts.Include(p=> p.ProductVariants).FirstOrDefaultAsync(x=>x.Id == id);
    
}