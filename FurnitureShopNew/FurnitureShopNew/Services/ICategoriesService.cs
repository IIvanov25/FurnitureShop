using FurnitureShopNew.Models;

namespace FurnitureShopNew.Services
{
    public interface ICategoriesService
    {
        List<FurnitureTypeCategory> GetAllCategories();
        FurnitureTypeCategory GetCategoryById(int id);
        FurnitureTypeCategory GetCategoryByName(string name);
        void AddCategory(FurnitureTypeCategory category);
        void UpdateCategory(FurnitureTypeCategory oldcategory, FurnitureTypeCategory newcategory);
        void DeleteCategory(FurnitureTypeCategory category);
    }
}