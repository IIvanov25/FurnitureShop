using FurnitureShopNew.Models;

namespace FurnitureShopNew.Services
{
    public interface ICategoriesService
    {
        public void RemoveProductById(int id);
        void AddProduct(FurnitureTypeCategory category);
        List<FurnitureTypeCategory> GetAllCategories(FurnitureTypeCategory categories);
    }
}