using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class CategoriesService : ICategoriesService
{
    private readonly ShopDbContext _context;
    private readonly ICategoriesRepo _categoriesRepo;
    public CategoriesService(ICategoriesRepo categoriesRepo, ShopDbContext context)
    {
        _context = context;
        _categoriesRepo = categoriesRepo;
    }

    public List<FurnitureTypeCategory> GetAllCategories()
    {
        return _categoriesRepo.GetAllCategories();
    }

    public void AddCategory(FurnitureTypeCategory category)
    {
        _categoriesRepo.AddCategory(category);
        _context.SaveChanges();
    }


    public void UpdateCategory(FurnitureTypeCategory oldcategory, FurnitureTypeCategory newcategory)
    {
        _categoriesRepo.UpdateCategory(oldcategory, newcategory);
        _context.SaveChanges();
    }

    public void DeleteCategory(FurnitureTypeCategory category)
    {
        _categoriesRepo.DeleteCategory(category);
        _context.SaveChanges();
    }

    public FurnitureTypeCategory GetCategoryById(int id)
    {
        return _categoriesRepo.GetCategoryById(id);
    }
    public FurnitureTypeCategory GetCategoryByName(string name)
    {
        return _categoriesRepo.GetCategoryByName(name);
    }
}