namespace PPI_Test.GetAssetTypes
{
    using Xunit;
    using System.Net;
    using System.Net.Http;
    using PPI_Test.Factory;

    public class Test : IntegrationTest
    {
        private readonly string token;

        public Test(ApiWebApplicationFactory factory) : base(factory) 
        {
            token = factory.Configuration["BearerTokenTest"].ToString();
        }

        [Fact]
        [Trait("Categoria", "GetAssetTypes")]
        public void GetAssetTypes()
        {
            _client.DefaultRequestHeaders.Authorization = new("Bearer", token);
            HttpResponseMessage response = _client.GetAsync("/asset/types").GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}