using FurnitureShopNew.Models;
using System.Collections.Generic;

namespace FurnitureShopNew.Services
{
    public interface ICartService
    {
        void AddProductToCart(int cartId, int productId, int quantity);
        decimal GetDeliveryPrice(List<int> productIds);
        decimal GetPriceOfProducts(List<int> productIds);
        decimal GetTotalPrice(List<int> productIds);
        void MakeOrder(int cartId, string address);
        void RemoveProduct(int cartId, int productId, int quantity);
    }
}
