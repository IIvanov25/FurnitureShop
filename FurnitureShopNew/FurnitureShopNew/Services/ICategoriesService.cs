using System;

namespace FurnitureShopNew.Services
{
    public interface ICategoriesService
    {
        public void RemoveProductById(int id);
        void AddProduct(Categories category);
        List<Categories> GetAllCategories(Categories categories);
    }
}