using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShopNew.Repositories 
{
    public class CartRepo : ICartRepo
    {
        private readonly ShopDbContext _context;

        public CartRepo(ShopDbContext context)
        {
            _context = context;
        }

        public void AddProductToCart(int cartId, int productId, int quantity)
        {
            var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found");
            }

            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Product = product
                });
            }

            _context.SaveChanges();
        }

        public decimal GetDeliveryPrice(List<int> productIds)
        {
            decimal deliveryPrice = 0;
            decimal totalAmount = 0;

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found!");
                }
                totalAmount += product.Price;
            }

            if (totalAmount <= 1000)
            {
                deliveryPrice = 20;
            }
            else
            {
                deliveryPrice = 0;
            }

            return deliveryPrice;
        }

        public decimal GetPriceOfProducts(List<int> productIds)
        {
            decimal price = 0;

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
                price += product.Price;
            }

            return price;
        }

        public decimal GetTotalPrice(List<int> productIds)
        {
            decimal priceOfProducts = 0;
            decimal deliveryPrice = GetDeliveryPrice(productIds);

            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
                priceOfProducts += product.Price;
            }

            return priceOfProducts + deliveryPrice;
        }

        public void MakeOrder(int cartId, string address)
        {
            var cart = _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found!");
            }

            var productIds = cart.CartItems.Select(ci => ci.ProductId).ToList();
            decimal totalPrice = GetTotalPrice(productIds);

            if (totalPrice <= 0)
            {
                throw new ArgumentException("There is nothing in the cart! Please add products to place an order!");
            }

            var order = new Order
            {
                UserId = cart.UserId,
                CartId = cart.CartId,
                OrderDate = DateTime.Now,
                DeliveryPrice = GetDeliveryPrice(productIds),
                Address = address 
            };

            foreach (var item in cart.CartItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    product.StockQuantity -= item.Quantity;
                }
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            ResetCartItems(cartId);
        }

        public void RemoveProduct(int cartId, int productId, int quantity)
        {
            var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found");
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem == null)
            {
                throw new ArgumentException("Product not found in cart");
            }

            cartItem.Quantity -= quantity;

            if (cartItem.Quantity <= 0)
            {
                cart.CartItems.Remove(cartItem);
            }

            _context.SaveChanges();
        }

        private void ResetCartItems(int cartId)
        {
            var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);

            if (cart != null)
            {
                cart.CartItems.Clear();
                _context.SaveChanges();
            }
        }
    }
}
