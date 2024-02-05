namespace PPI_API.Models
{
    public class AssetModel
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int AssetType { get; set; }
        public decimal UnitPrice { get; set; }
    }
}