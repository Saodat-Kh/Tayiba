using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.Category;

public class CategoryRepository(ApplicationDataContext context, IMemoryCache cache) : ICategoryRepository
{
    private readonly string key = "Category";
    public async Task<int> AddCategory(Domain.Entities.Category category)
    {
        context.Categories.Add(category);
        var res = await context.SaveChangesAsync();
        if(res> 0)
            cache.Remove(key);
        return res;
    }

    public async Task<int> UpdateCategory(Domain.Entities.Category category)
    {
        context.Categories.Update(category);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<int> DeleteCategory(Domain.Entities.Category category)
    {
        context.Categories.Remove(category);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<List<Domain.Entities.Category>> GetCategories()
    {
        if (!cache.TryGetValue(key, out var value))
        {
            var res = await context.Categories.ToListAsync();
            cache.Set(key , res,TimeSpan.FromMinutes(15));
        }
        return cache.Get<List<Domain.Entities.Category>>(key);
    }

    public async Task<Domain.Entities.Category> GetCategoryById(int id)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }
}