namespace PPI_API.Domain
{
    public class Order
    {
        public int AccountId { get; set; }
        public int AssetId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Commission { get; set; }
        public decimal Taxes { get; set; }
        public char Operation { get; set; }
        public decimal TotalAmount { get; set; }
    }
}