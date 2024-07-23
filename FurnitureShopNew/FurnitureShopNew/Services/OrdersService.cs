using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;

namespace FurnitureShopNew.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepo _ordersRepo;

        public OrdersService(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        void IOrdersService.AddOrders(Order order)
        {
            throw new NotImplementedException();
        }

        void IOrdersService.DeleteOrders(int orderId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IOrdersService.GetAllOrders()
        {
            throw new NotImplementedException();
        }

        List<Order> IOrdersService.GetAllOrdersByUser(User customer)
        {
            throw new NotImplementedException();
        }

        Order IOrdersService.GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        void IOrdersService.UpdateOrders(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
