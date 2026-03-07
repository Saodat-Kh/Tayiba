using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository;

public class CategoryRepository(ApplicationDataContext context, IMemoryCache cache) : ICategoryRepository
{
    private readonly string key = "Category";
    public async Task<int> AddCategory(Category category)
    {
        context.Categories.Add(category);
        var res = await context.SaveChangesAsync();
        if(res> 0)
            cache.Remove(key);
        return res;
    }

    public async Task<int> UpdateCategory(Category category)
    {
        context.Categories.Update(category);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<int> DeleteCategory(Category category)
    {
        context.Categories.Remove(category);
        var res = await context.SaveChangesAsync();
        if(res > 0)
            cache.Remove(key);
        return res;
    }

    public async Task<List<Category>> GetCategories()
    {
        if (!cache.TryGetValue(key, out var value))
        {
            var res = await context.Categories.ToListAsync();
            cache.Set(key , res,TimeSpan.FromMinutes(15));
        }
        return cache.Get<List<Category>>(key);
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }
}