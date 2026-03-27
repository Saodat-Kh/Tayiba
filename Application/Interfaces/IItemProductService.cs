using Application.Dtos.Category;
using Application.Dtos.ItemProduct;
using Application.Dtos.Product;
using Application.Responses;

namespace Application.Interfaces;

public interface IItemProductService
{
    Task<Response<string>>  CreateItemProduct(CreateItemProductDto createItemProductDto);
    Task<Response<string>>  UpdateItemProduct(UpdateItemProductDto updateItemProductDto);
    Task<Response<string>>  DeleteItemProduct(int id);
    Task<Response<List<GetItemProductDto>>> GetAllItemProducts();
}