using FurnitureShopNew;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class ProductService : IProductService
{
    void IProductService.AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    List<Product> IProductService.GetAllProducts(Product products)
    {
        throw new NotImplementedException();
    }

    Product IProductService.RemoveProductById(int id)
    {
        throw new NotImplementedException();
    }
}