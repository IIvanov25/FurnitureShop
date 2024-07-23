using FurnitureShopNew.Models;

public class ProductService : IProductService
{
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