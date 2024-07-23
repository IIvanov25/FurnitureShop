using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface ICategoriesRepo
    {
        IEnumerable<FurnitureTypeCategory> GetAllCategories();
        FurnitureTypeCategory GetCategoryById(int id);
        void AddCategory(FurnitureTypeCategory category);
        void UpdateCategory(FurnitureTypeCategory categoryOld, FurnitureTypeCategory categoryNew);
        void DeleteCategory(FurnitureTypeCategory category);
    }
}