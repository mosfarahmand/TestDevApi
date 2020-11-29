using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace DevTestApi.Test
{
    public class TestApi
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public TestApi()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("https://localhost:5005/api/Photo/random-cat-flip-photo");
           
            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}