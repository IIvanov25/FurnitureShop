using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;

public class ProductService : IProductService
{
 
    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}