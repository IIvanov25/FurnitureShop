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
            _ordersRepo.DeleteOrders(orderId);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepo.GetAllOrders();
        }

        public List<Order> GetAllOrdersByUser(User customer)
        {
            return _ordersRepo.GetAllOrdersByUser(customer);
        }

        public Order GetOrderById(int orderId)
        {
            return _ordersRepo.GetOrderById(orderId);
        }

        public void UpdateOrders(Order order)
        {
            _ordersRepo.UpdateOrders(order);
        }
    }
}
