namespace PPI_API.Actions.Create
{
    using System.Text.Json.Serialization;

    public class CreateOrderResponse
    {
        [JsonIgnore]
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}