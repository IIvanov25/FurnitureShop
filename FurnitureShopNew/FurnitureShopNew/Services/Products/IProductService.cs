using FurnitureShopNew.Models;
using System.Threading.Tasks;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int productId);
}