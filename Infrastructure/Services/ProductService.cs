using System.Net;
using Application.Dtos.ItemProduct;
using Application.Dtos.Product;
using Application.Dtos.ProductVariant;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.Product;

namespace Infrastructure.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    
        
        public async Task<Response<string>> CreateProduct(CreateProductDto createProductDto)
         { 
             try
             {

        var product = new Product()
        {
            Name = createProductDto.Name,
            Price = createProductDto.Price,
            CategoryId = createProductDto.CategoryId,
            Description = createProductDto.Description,
            
        };
        var res =  await repository.AddProduct(product);
        return res > 0
        ? new Response<string>(HttpStatusCode.Created, "Product created successfully")
        : new Response<string>(HttpStatusCode.BadRequest, "Product creation failed");
        
          }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
         }

        public async Task<Response<string>> UpdateProduct(UpdateProductDto updateProductDto)
        {try
            {

                var oldProduct = await repository.GetProductById(updateProductDto.Id);
                if (oldProduct == null) return new Response<string>(HttpStatusCode.NotFound, "Product not found");
                oldProduct.Name = updateProductDto.Name ?? oldProduct.Name;
                oldProduct.Description = updateProductDto.Description ?? oldProduct.Description;
                oldProduct.Price = updateProductDto.Price ?? oldProduct.Price;
                oldProduct.CategoryId = updateProductDto.CategoryId ??  oldProduct.CategoryId;
                var res = await repository.UpdateProduct(oldProduct);
                return res > 0
                    ?   new Response<string>(HttpStatusCode.OK, "Product updated successfully")
                    :   new Response<string>(HttpStatusCode.BadRequest, "");
            }
            catch 
            {
                return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        public async Task<Response<string>> DeleteProduct(int id)
        {
            var pro = await repository.GetProductById(id);
            if (pro == null)
            {
                return new Response<string>(HttpStatusCode.NotFound, "Product not found");
            }
            var res = await repository.DeleteProduct(pro);
            return res > 0
                ? new Response<string>(HttpStatusCode.OK, "Product deleted successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "Product deletion failed");
        }

        public async Task<Response<List<GetProductDto>>> GetAllProducts()
        {
            var res = await repository.GetAllProduct();
            if (res == null) return new Response<List<GetProductDto>>(HttpStatusCode.NotFound, "Product not found");
            var rew = res.Select(p=> new GetProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId ?? 0,
                Price = p.Price,
                CreatedAt = p.CreatedAt,
                Items = p.ItemProducts.Select(o=> new GetItemProductDto()
                {
                    Id = o.Id,
                    Quantity = o.Quantity,
                    Photo = o.Photo ?? new List<string>(),
                    CreatedAt = o.CreatedAt,
                    Variants = o.ProductVariants.Select(x=> new GetProductVariantDto()
                    {
                         Id = x.Id,
                         Color = x.Color,
                         Size = x.Size
                    }).ToList()
                }).ToList()
            }).ToList();
            return new Response<List<GetProductDto>>(rew);
        }
    
}