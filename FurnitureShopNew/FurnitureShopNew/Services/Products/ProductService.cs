using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;

public class ProductService : IProductService
{
    private IProductRepo _productRepo;
    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    Product IProductService.GetProductById(int id)
    {
        return _productRepo.
    }
    void IProductService.GetProductByName(string name)
    {

    }
    void IProductService.AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    List<Product> IProductService.GetAllProducts(Product products)
    {
        throw new NotImplementedException();
    }

    Product IProductService.RemoveProductById(int id)
    {
        throw new NotImplementedException();
    }
}