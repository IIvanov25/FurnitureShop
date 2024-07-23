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

        void IOrdersRepo.AddOrders(Order orders)
        {
            _context.Orders.Add(orders);
        }

        void IOrdersRepo.DeleteOrders(int ordersId)
        {
            
        }

        IEnumerable<Order> IOrdersRepo.GetAllOrders()
        {
            throw new NotImplementedException();
        }

        List<Order> IOrdersRepo.GetAllOrdersByUser(User customer)
        {
            throw new NotImplementedException();
        }

        Order IOrdersRepo.GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        void IOrdersRepo.UpdateOrders(Order order)
        {
            throw new NotImplementedException();
        }
    }
}