using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.Product;

public class ProductRepository(ApplicationDataContext context, IMemoryCache cache) : IProductRepository
{
    private readonly string key = "Product";
    public async Task<int> AddProduct(Domain.Entities.Product product)
    {
        context.Products.Add(product);
        var res =await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<int> UpdateProduct(Domain.Entities.Product product)
    {
        context.Products.Update(product);
        var res = await context.SaveChangesAsync();
        if(res > 0) 
            cache.Remove(key);
        return res;
    }

    public async Task<int> DeleteProduct(Domain.Entities.Product product)
    {
        context.Products.Remove(product);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<List<Domain.Entities.Product>> GetAllProduct()
    {
        if (!cache.TryGetValue(key, out var value))
        {
            var res = await context.Products.Include(p=> p.ItemProducts).ToListAsync();
            cache.Set(key,res, TimeSpan.FromMinutes(25));
        }

        return cache.Get<List<Domain.Entities.Product>>(key);
    }

    public async Task<Domain.Entities.Product> GetProductById(int id)
    {
        return await context.Products.FirstOrDefaultAsync(x=> x.Id == id);
    }
}