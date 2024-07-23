using FurnitureShopNew;
using System.Collections.Generic;

namespace FurnitureShopNew.Repositories.Categories
{
    public interface ICategoriesRepo
    {
        IEnumerable<FurnitureTypeCategory> GetAllCategories();
        FurnitureTypeCategory GetCategoryById(int id);
        void AddCategory(FurnitureTypeCategory category);
        void UpdateCategory(FurnitureTypeCategory categoryold, FurnitureTypeCategory categorynew);
        void DeleteCategory(FurnitureTypeCategory category);
    }
}