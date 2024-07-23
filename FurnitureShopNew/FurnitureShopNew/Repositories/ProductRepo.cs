using FurnitureShopNew;
using FurnitureShopNew.Data;
using FurnitureShopNew.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class ProductRepo : IProductRepo
{
    private readonly ShopDbContext _context;
    public ProductRepo(ShopDbContext context)
    {
        _context = context;
    }
    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
   
    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
    public IEnumerable<Product> GetAllProduct()
    {
        return _context.Products.ToList();
    }
    
    public Product GetProductById(int id)
    {
        return _context.Products.Single(c => c.ProductId == id);
    }
    public int GetQuantityById(int id)
    {
        return _context.Products.Count(p => p.ProductId == id);
    }
    
    public List<Product> SearchProductByCategory(int id)
    {
        return _context.Products.Where(p => p.CategoryId == id).ToList();
    }
    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

}
