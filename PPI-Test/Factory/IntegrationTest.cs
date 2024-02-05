namespace PPI_Test.Factory
{
    using Xunit;
    using System.Net.Http;

    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly HttpClient _client;
        protected readonly ApiWebApplicationFactory _factory;

        protected IntegrationTest(ApiWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }
    }
}