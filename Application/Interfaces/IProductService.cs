using Application.Dtos.Category;
using Application.Dtos.Product;
using Application.Responses;

namespace Application.Interfaces;

public interface IProductService
{
    Task<Response<string>> CreateProduct(CreateProductDto createProductDto);
    Task<Response<string>> UpdateProduct(UpdateProductDto updateProductDto);
    Task<Response<string>> DeleteProduct(int id);
    Task<Response<List<GetProductDto>>> GetAllProducts();
}