using FurnitureShopNew.Models;
public interface IProductService
{
    Product RemoveProductById(int id);
    void AddProduct(Product product);
    List<Product> GetAllProducts(Product products);
}