using Infrastructure.Services;

namespace Infrastructure.Repository.ProductVariant;

public interface IProductVariantRepository
{
   Task<int> AddProductVariant(Domain.Entities.ProductVariant productVariant); 
}