using System.Collections.Generic;
public interface IOrdersRepo
{
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int OrderId);
    void AddOrders(Order Orders);
    void UpdateOrders(Order Orders);
    void DeleteOrders(int OrdersId);
    List<Order> GetAllOrdersByUser(User customer);
}