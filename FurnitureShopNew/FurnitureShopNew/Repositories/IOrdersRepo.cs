using FurnitureShopNew.Models;
using System.Collections.Generic;


public interface IOrdersRepo
{
    IEnumerable<Orders> GetAllOrders();
    Orders GetOrdersById(int OrdersId);
    void AddOrders(Orders Orders);
    void UpdateOrders(Orders Orders);
    void DeleteOrders(int OrdersId);
}