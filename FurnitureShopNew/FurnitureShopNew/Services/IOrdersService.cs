namespace FurnitureShopNew.Services
{
    public interface IOrdersService 
    {
        void AddOrders(Order order);
        void DeleteOrders(int orderId);
        IEnumerable<Order> GetAllOrders();
        List<Order> GetAllOrdersByUser(User customer);
        Order GetOrderById(int orderId);
        void UpdateOrders(Order order);
    }
}
