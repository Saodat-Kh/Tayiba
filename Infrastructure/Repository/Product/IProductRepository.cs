namespace Infrastructure.Repository.Product;

public interface IProductRepository
{
    Task<int> AddProduct(Domain.Entities.Product product);
    Task<int> UpdateProduct(Domain.Entities.Product product);
    Task<int> DeleteProduct(Domain.Entities.Product product);
    Task<List<Domain.Entities.Product>> GetAllProduct();
    Task<Domain.Entities.Product>  GetProductById(int id); 
}