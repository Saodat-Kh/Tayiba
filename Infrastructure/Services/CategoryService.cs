using System.Net;
using Application.Dtos.Category;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class CategoryService(ICategoryRepository repository,IMapper mapper) : ICategoryService
{
    public async Task<Response<string>> CreateCategory(CreateCategoryDto categoryDto)
    {
        var map = mapper.Map<Category>(categoryDto);
        var res = await repository.AddCategory(map);
        return res > 0 
            ? new Response<string>(HttpStatusCode.Created, "Category created successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Category creation failed");
    }

    public async Task<Response<string>> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        var map = mapper.Map<Category>(categoryDto);
        var res = await repository.UpdateCategory(map);
        return res > 0
            ? new Response<string>(HttpStatusCode.OK, "Category updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Category updation failed");
    }

    public async Task<Response<string>> DeleteCategory(int id)
    {
        var old = await repository.GetCategoryById(id);
        if(old == null)
            return new Response<string>(HttpStatusCode.NotFound, "Category not found");
        var res = await repository.DeleteCategory(old);
        return res > 0
            ? new Response<string>(HttpStatusCode.OK, "Category deleted successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Category deletion failed");
    }

    public async Task<Response<List<GetCategoryDto>>> GetAllCategories()
    {
        var res = await repository.GetCategories();
        var map = mapper.Map<List<GetCategoryDto>>(res);
        return new Response<List<GetCategoryDto>>(map);
    }
}