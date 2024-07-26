using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;

public class ProductService : IProductService
{
    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        try
        {
            return await _productRepo.GetAllProductsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new ArgumentException("No products found!");
        }
    }
    public Task<Product> GetProductByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}