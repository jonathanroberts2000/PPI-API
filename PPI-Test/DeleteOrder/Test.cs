namespace PPI_Test.DeleteOrder
{
    using Xunit;
    using System.Net;
    using Newtonsoft.Json;
    using PPI_API.Commons;
    using System.Net.Http;
    using PPI_Test.Factory;
    using System.Net.Http.Json;
    using PPI_API.Actions.Create;
    using PPI_API.Actions.Delete;

    public class Test : IntegrationTest
    {
        private readonly string token;

        public Test(ApiWebApplicationFactory factory) : base(factory) 
        {
            token = factory.Configuration["BearerTokenTest"].ToString();
        }

        [Fact]
        [Trait("Categoria", "Delete")]
        public void DeleteOrder()
        {
            string uri = CreateOrder();

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.DeleteAsync($"/order{uri}").GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        [Trait("Categoria", "Delete")]
        public void DeleteOrder_OrderIdValidator()
        {
            DeleteOrderRequest request = new()
            {
                OrderId = -58
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.DeleteAsync($"/order/{request.OrderId}").GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("OrderIdValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Delete")]
        public void DeleteOrder_OrderIdNotExists()
        {
            DeleteOrderRequest request = new()
            {
                OrderId = 150
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.DeleteAsync($"/order/{request.OrderId}").GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("010002", resultJson.Errors[0].Code);
        }

        private string CreateOrder()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 9,
                Operation = 'C',
                Price = 10,
                Quantity = 2
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();

            return response.Headers.Location.OriginalString;
        }
    }
}
