using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{

    public class ProductRepo : IProductRepo
    {
        private readonly ShopDbContext _context;
        public ProductRepo(ShopDbContext context)
        {
            _context = context;
        }

        void IProductRepo.AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        void IProductRepo.DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductRepo.GetAllProducts()
        {
            throw new NotImplementedException();
        }

        Product IProductRepo.GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        int IProductRepo.GetQuantityById(int id)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductRepo.SearchProductByCategory(int id)
        {
            throw new NotImplementedException();
        }

        void IProductRepo.UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}