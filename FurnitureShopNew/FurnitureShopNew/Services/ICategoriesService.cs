using FurnitureShopNew.Models;

namespace FurnitureShopNew.Services
{
    public interface ICategoriesService
    {
        public List<FurnitureTypeCategory> GetAllCategories();
        public FurnitureTypeCategory GetCategoryById(int id);
        public FurnitureTypeCategory GetCategoryByName(string name);
        public void AddCategory(FurnitureTypeCategory category);
        public void UpdateCategory(FurnitureTypeCategory oldcategory, FurnitureTypeCategory newcategory);
        public void DeleteCategory(FurnitureTypeCategory category);
    }
}