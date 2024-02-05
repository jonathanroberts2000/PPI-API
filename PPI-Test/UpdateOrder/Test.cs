namespace PPI_Test.UpdateOrder
{
    using Xunit;
    using System.Net;
    using PPI_API.Commons;
    using Newtonsoft.Json;
    using System.Net.Http;
    using PPI_Test.Factory;
    using System.Net.Http.Json;
    using PPI_API.Actions.Create;
    using PPI_API.Actions.Update;

    public class Test : IntegrationTest
    {
        private readonly string token;

        public Test(ApiWebApplicationFactory factory) : base(factory) 
        {
            token = factory.Configuration["BearerTokenTest"].ToString();
        }

        [Fact]
        [Trait("Categoria", "Update")]
        public void UpdateOrder()
        {
            string uri = CreateOrder();

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PutAsync($"/order{uri}/1", null).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        [Trait("Categoria", "Update")]
        public void UpdateOrder_OrderIdValidator()
        {
            UpdateOrderRequest request = new()
            {
                OrderId = 0,
                StatusId = 1
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PutAsync($"/order/{request.OrderId}/{request.StatusId}", null).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("OrderIdValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Update")]
        public void UpdateOrder_StatusIdValidator()
        {
            UpdateOrderRequest request = new()
            {
                OrderId = 1,
                StatusId = 2
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PutAsync($"/order/{request.OrderId}/{request.StatusId}", null).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("StatusIdValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Update")]
        public void UpdateOrder_OrderIdNotExists()
        {
            UpdateOrderRequest request = new()
            {
                OrderId = 10550,
                StatusId = 1
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PutAsync($"/order/{request.OrderId}/{request.StatusId}", null).GetAwaiter().GetResult();
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