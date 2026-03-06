using Application.Dtos.Category;
using Application.Responses;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<Response<string>> CreateCategory(CreateCategoryDto categoryDto);
    Task<Response<string>> UpdateCategory(UpdateCategoryDto categoryDto);
    Task<Response<string>> DeleteCategory(int id);
    Task<Response<string>> GetAllCategories();
}