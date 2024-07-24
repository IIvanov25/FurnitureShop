using FurnitureShopNew;
using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class OrdersRepo : IOrdersRepo
{
    private readonly ShopDbContext _context;
    public OrdersRepo(ShopDbContext context)
    {
        _context = context;
    }
    public void AddOrders(Order orders)
    {
        _context.Orders.Add(orders);
        _context.SaveChanges();
    }
    public void DeleteOrders(int ordersId)
    {
        var orderToRemove = _context.Orders.First(o => o.OrderId == ordersId);
        _context.Remove(orderToRemove);
        _context.SaveChanges();
    }
    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }
    public List<Order> GetAllOrdersByUser(User customer)
    {
        return _context.Orders.Where(o => o.UserId == customer.UserId).ToList();
    }
    public Order GetOrderById(int orderId)
    {
        return _context.Orders.Single(c => c.OrderId == orderId);
    }
    public void UpdateOrders(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }
}