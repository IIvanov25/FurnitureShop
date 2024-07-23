using FurnitureShopNew.Models;
using System.Collections.Generic;
using FurnitureShop;

public class CategoriesService : ICatedoriesService
{
    void RemoveProductById(int id);
    void AddProduct(Categories category);
    List<FurnitureTypeCategory> GetAllCategories(Categories categories);
}