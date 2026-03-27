using System.Net;
using Application.Dtos.ProductVariant;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.ProductVariant;

namespace Infrastructure.Services;

public class ProductVariantService(IProductVariantRepository repository, IMapper mapper) : IProductVariantService
{
    public async Task<Response<string>> CreateProductVariant(CreateVariantProductDto productVariant)
    {
        var product = new ProductVariant()
        {
            
            ProductId = productVariant.ProductId,
            ItemProductId = productVariant.ItemProductId,
            Color = productVariant.Color,
            Size = productVariant.Size,
            
        };
        var res = await repository.AddProductVariant(product);
        return res > 0 
            ? new Response<string>(HttpStatusCode.Created, "Created ProductVariant successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Failed to create ProductVariant");
    }

   
}