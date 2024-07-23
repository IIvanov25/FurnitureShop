using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface IOrdersRepo
    {
        void AddOrders(Order orders);
        void DeleteOrders(int ordersId);
        IEnumerable<Order> GetAllOrders();
        List<Order> GetAllOrdersByUser(User customer);
        Order GetOrderById(int orderId);
        void UpdateOrders(Order order);
    }
}