namespace PPI_API.Actions.Create
{
    public class CreateOrderRequest
    {
        public int AssetId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public char Operation { get; set; }
    }
}