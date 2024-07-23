using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;

public class ProductService : IProductService
{
    private IProductRepo _productRepo;
    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts(Product products)
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Product GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public Product RemoveProductById(int id)
    {
        throw new NotImplementedException();
    }
}