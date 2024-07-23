using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> SearchProductByCategory(int id);
        int GetQuantityById(int id);
    }
}
