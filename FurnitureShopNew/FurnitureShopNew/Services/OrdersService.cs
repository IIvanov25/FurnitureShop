using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;

namespace FurnitureShopNew.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ShopDbContext _context;
        private readonly IOrdersRepo _ordersRepo;

        public OrdersService(IOrdersRepo ordersRepo, ShopDbContext context)
        {
            _ordersRepo = ordersRepo;
            _context = context;
        }

        public void AddOrders(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrders(int orderId)
        {
            var orderToDelete = _context.Orders.First(o => o.OrderId == orderId);
            _context.Orders.Remove(orderToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public List<Order> GetAllOrdersByUser(User customer)
        {
            return _context.Orders.Where(o => o.Cart.UserId == customer.UserId).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            var order = _context.Orders.First(o => o.OrderId == orderId);
            return order;
        }

        public void UpdateOrders(Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(eo => eo.OrderId == order.OrderId);

            if (existingOrder == null)
            {
                throw new ArgumentException("Order not found!");
            }
            else
            {
                existingOrder.OrderId = order.OrderId;
                existingOrder.CartId = order.CartId;
                existingOrder.DeliveryPrice = order.DeliveryPrice;
                existingOrder.Address = order.Address;
                _context.Orders.Update(existingOrder);
            }
            _context.SaveChanges();
        }
    }
}
