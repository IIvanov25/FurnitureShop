using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface IOrdersRepo
    {
        public void AddOrders(Order orders);
        public void DeleteOrders(int ordersId);
        public IEnumerable<Order> GetAllOrders();
        public List<Order> GetAllOrdersByUser(User customer);
        public Order GetOrderById(int orderId);
        public void UpdateOrders(Order order);
    }
}