namespace PPI_API.Models
{
    public class OrderShortModel
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string Ticker { get; set; }
        public string AssetType { get; set; }
        public decimal TotalAmount { get; set; }
    }
}