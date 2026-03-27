using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository.ItemProductRepository;

public interface IItemProductRepository
{
    Task<int> CreateItemProductAsync(ItemProduct item);
    Task<int> UpdateItemProductAsync(ItemProduct item);
    Task<ItemProduct> GetItemProductById(int id);
}