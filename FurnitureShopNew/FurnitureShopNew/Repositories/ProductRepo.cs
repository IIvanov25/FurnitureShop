using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShopNew.Repositories
{

    public class ProductRepo : IProductRepo
    {
        private readonly ShopDbContext _context;
        public ProductRepo(ShopDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetQuantityById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> SearchProductByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}