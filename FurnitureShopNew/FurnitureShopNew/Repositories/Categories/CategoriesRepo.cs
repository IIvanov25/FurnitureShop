using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public class CategoriesRepo : ICategoriesRepo
    {
        void ICategoriesRepo.AddCategory(FurnitureTypeCategory category)
        {
            throw new NotImplementedException();
        }

        void ICategoriesRepo.DeleteCategory(FurnitureTypeCategory category)
        {
            throw new NotImplementedException();
        }

        IEnumerable<FurnitureTypeCategory> ICategoriesRepo.GetAllCategories()
        {
            throw new NotImplementedException();
        }

        FurnitureTypeCategory ICategoriesRepo.GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        void ICategoriesRepo.UpdateCategory(FurnitureTypeCategory categoryold, FurnitureTypeCategory categorynew)
        {
            throw new NotImplementedException();
        }
    }
}