using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureShopNew.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ShopDbContext _context;

        public ProductRepo(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }
    }
}
