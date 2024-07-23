

namespace FurnitureShopNew.Repositories
{
    public interface ICartRepo
    {
        void AddProductToCart(int cartId, int productId, int quantity);
        void RemoveProduct(int cartId, int productId, int quantity);
        void MakeOrder(int cartId, string address);
        decimal GetPriceOfProducts(List<int> productIds);
        decimal GetDeliveryPrice(List<int> productIds);
        decimal GetTotalPrice(List<int> productIds);
    }
}