namespace PPI_Test.CreateOrder
{
    using Xunit;
    using System.Net;
    using System.Net.Http;
    using PPI_API.Commons;
    using Newtonsoft.Json;
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
        [Trait("Categoria", "Create")]
        public void CreateOrder_FCI()
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
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            Assert.NotNull(response.Headers.Location);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_Accion()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 2,
                Operation = 'V',
                Quantity = 5
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            Assert.NotNull(response.Headers.Location);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_Bono()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 7,
                Operation = 'C',
                Price = 21.75m,
                Quantity = 12
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            Assert.NotNull(response.Headers.Location);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_AssetIdValidator()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 0,
                Operation = 'C',
                Price = 10,
                Quantity = 10
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("AssetIdValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_QuantityValidator()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 7,
                Operation = 'V',
                Price = 25,
                Quantity = 0
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("QuantityValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_OperationValidator()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 7,
                Operation = 'P',
                Price = 4,
                Quantity = 1
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionRequired, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("OperationValidator", resultJson.Errors[0].Code);
        }

        [Fact]
        [Trait("Categoria", "Create")]
        public void CreateOrder_AssetIdNotExists()
        {
            CreateOrderRequest request = new()
            {
                AssetId = 100,
                Operation = 'C',
                Price = 10,
                Quantity = 2
            };

            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.PostAsJsonAsync("/order", request).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

            string responseData = response.Content.ReadAsStringAsync().Result;
            Response<object> resultJson = JsonConvert.DeserializeObject<Response<object>>(responseData);

            Assert.Equal("010001", resultJson.Errors[0].Code);
        }
    }
}