namespace Infrastructure.Repository.Category;

public interface ICategoryRepository
{
    Task<int> AddCategory(Domain.Entities.Category category);
    Task<int> UpdateCategory(Domain.Entities.Category category);
    Task<int> DeleteCategory(Domain.Entities.Category category);
    Task<List<Domain.Entities.Category>> GetCategories();
    Task<Domain.Entities.Category> GetCategoryById(int id);
}