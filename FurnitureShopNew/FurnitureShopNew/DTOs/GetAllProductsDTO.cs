using FurnitureShopNew.Models;
using Org.BouncyCastle.Tls.Crypto;

namespace FurnitureShopNew.DTOs
{
    public class GetAllProductsDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int RoomCategoryId { get; set; }
        public int FurnitureTypeCategoryId { get; set; }


        public GetAllProductsDTO(int productId, string name, string imageUrl, string description, decimal price, int stockQuantity, int roomCategoryId, int furnitureTypeCategoryId)
        {
            this.ProductId = productId;
            this.Name = name;
            this.ImageUrl = imageUrl;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
            this.RoomCategoryId = roomCategoryId;
            this.FurnitureTypeCategoryId = furnitureTypeCategoryId;
        }
    }
}
