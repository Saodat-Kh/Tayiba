using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public interface ICategoryRepository
{
    Task<int> AddCategory(Category category);
    Task<int> UpdateCategory(Category category);
    Task<int> DeleteCategory(Category category);
    Task<List<Category>> GetCategories();
    Task<Category> GetCategoryById(int id);
}