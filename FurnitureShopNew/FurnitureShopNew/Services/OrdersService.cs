
namespace FurnitureShopNew.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo _ordersRepo;

        public OrdersService(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        public void AddOrders(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _ordersRepo.AddOrders(order);
        }

        public void DeleteOrders(int orderId)
        {
            var order = _ordersRepo.GetOrderById(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {orderId} not found.");
            }

            _ordersRepo.DeleteOrders(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepo.GetAllOrders();
        }

        public List<Order> GetAllOrdersByUser(User customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return _ordersRepo.GetAllOrdersByUser(customer);
        }

        public Order GetOrderById(int orderId)
        {
            var order = _ordersRepo.GetOrderById(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {orderId} not found.");
            }

            return order;
        }

        public void UpdateOrders(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            var existingOrder = _ordersRepo.GetOrderById(order.OrderId);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Order with id {order.OrderId} not found.");
            }

            _ordersRepo.UpdateOrders(order);
        }
    }
}
