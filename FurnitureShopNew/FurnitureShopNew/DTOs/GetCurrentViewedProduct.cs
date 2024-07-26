namespace FurnitureShopNew.DTOs
{
    public class GetCurrentViewedProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }


        public GetCurrentViewedProduct(int productId, string name, string imageUrl, string description, decimal price, int stockQuantity)
        {
            this.ProductId = productId;
            this.Name = name;
            this.ImageUrl = imageUrl;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }
    }
   
}
