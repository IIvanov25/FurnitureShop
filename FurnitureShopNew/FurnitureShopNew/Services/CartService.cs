using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureShopNew.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly ShopDbContext _context;

        public CartService(ICartRepo cartRepo, ShopDbContext context)
        {
            _cartRepo = cartRepo;
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

            _cartRepo.AddProductToCart(cartId, productId, quantity);
        }

        public decimal GetDeliveryPrice(List<int> productIds)
        {
            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
            }

            return _cartRepo.GetDeliveryPrice(productIds);
        }

        public decimal GetPriceOfProducts(List<int> productIds)
        {
            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
            }

            return _cartRepo.GetPriceOfProducts(productIds);
        }

        public decimal GetTotalPrice(List<int> productIds)
        {
            foreach (var productId in productIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
            }

            return _cartRepo.GetTotalPrice(productIds);
        }

        public void MakeOrder(int cartId, string address)
        {
            var cart = _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.CartId == cartId);

            if (cart == null)
            {
                throw new ArgumentException("Cart not found");
            }

            var productIds = cart.CartItems.Select(ci => ci.ProductId).ToList();
            decimal totalPrice = GetTotalPrice(productIds);

            if (totalPrice <= 0)
            {
                throw new ArgumentException("There is nothing in the cart! Please add products to place an order!");
            }

            _cartRepo.MakeOrder(cartId, address);
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

            _cartRepo.RemoveProduct(cartId, productId, quantity);
        }
    }
}

