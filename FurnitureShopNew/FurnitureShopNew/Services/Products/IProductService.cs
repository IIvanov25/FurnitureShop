using FurnitureShopNew.Models;
public interface IProductService
{
    Product GetProductById(int id);
    Product GetProductByName(string name);
    Product RemoveProductById(int id);
    void AddProduct(Product product);
    List<Product> GetAllProducts(Product products);
}