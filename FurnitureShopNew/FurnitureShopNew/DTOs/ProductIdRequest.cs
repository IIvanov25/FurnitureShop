namespace FurnitureShopNew.DTOs
{
    public class ProductIdRequest
    {
        public int ProductId { get; set; }

        public ProductIdRequest(int productId)
        {
            this.ProductId = productId;
        }
    }
}
