using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> SearchProductByCategory(int id);
        int GetQuantityById(int id);
    }
}
