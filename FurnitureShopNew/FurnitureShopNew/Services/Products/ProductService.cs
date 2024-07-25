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
        return await _productRepo.GetAllProductsAsync();
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _productRepo.GetProductByIdAsync(productId);
    }
}
