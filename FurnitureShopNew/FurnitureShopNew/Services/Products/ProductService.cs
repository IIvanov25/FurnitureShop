using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;

public class ProductService : IProductService
{

    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}
