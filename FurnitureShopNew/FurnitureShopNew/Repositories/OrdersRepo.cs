using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
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
            var order = _context.Orders.First(o => o.OrderId == ordersId);
            _context.Orders.Remove(order);
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