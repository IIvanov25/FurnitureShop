using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }
}
