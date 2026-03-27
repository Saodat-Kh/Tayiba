using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.ProductVariant;

public class ProductVariantRepository(ApplicationDataContext context, IMemoryCache cache) : IProductVariantRepository
{
    private readonly string key = "ProductVariant";
    public async Task<int> AddProductVariant(Domain.Entities.ProductVariant productVariant)
    {
        context.ProductVariants.Add(productVariant);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }
}