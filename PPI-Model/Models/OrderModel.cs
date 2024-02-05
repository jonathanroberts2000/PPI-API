namespace PPI_API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AssetName { get; set; }
        public string AssetTypeName { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public char Operation { get; set; }
        public string Status { get; set; }
        public decimal Commission { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalAmount { get; set; }
    }
}