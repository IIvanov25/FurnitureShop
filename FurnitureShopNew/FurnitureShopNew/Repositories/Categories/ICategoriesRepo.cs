using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface ICategoriesRepo
    {
        public List<FurnitureTypeCategory> GetAllCategories();
        public FurnitureTypeCategory GetCategoryById(int id);
        public FurnitureTypeCategory GetCategoryByName(string name);
        public void AddCategory(FurnitureTypeCategory category);
        public void UpdateCategory(FurnitureTypeCategory categoryOld, FurnitureTypeCategory categoryNew);
        public void DeleteCategory(FurnitureTypeCategory category);
    }
}