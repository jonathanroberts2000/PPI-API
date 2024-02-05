namespace PPI_Test.GetOrders
{
    using Xunit;
    using System.Net;
    using System.Net.Http;
    using PPI_Test.Factory;
    using System.Net.Http.Json;
    using PPI_API.Actions.Create;

    public class Test : IntegrationTest
    {
        private readonly string token;

        public Test(ApiWebApplicationFactory factory) : base(factory) 
        {
            token = factory.Configuration["BearerTokenTest"].ToString();
        }

        [Fact]
        [Trait("Categoria", "GetOrders")]
        public void GetOrders()
        {
            CreateOrders();

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.GetAsync($"/order/accounts").GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private void CreateOrders()
        {
            CreateOrderRequest requestCompra = new()
            {
                AssetId = 9,
                Operation = 'C',
                Price = 10,
                Quantity = 2
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            _client.PostAsJsonAsync("/order", requestCompra).GetAwaiter().GetResult();

            CreateOrderRequest requestVenta = new()
            {
                AssetId = 9,
                Operation = 'V',
                Price = 11,
                Quantity = 1
            };

            _client.PostAsJsonAsync("/order", requestVenta).GetAwaiter().GetResult();
        }
    }
}