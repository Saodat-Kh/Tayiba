using Application.Dtos.ProductVariant;
using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IProductVariantService
{
    Task<Response<string>> CreateProductVariant(CreatedProductVariantWithId productVariant);
}