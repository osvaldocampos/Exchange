using Exchange.Business.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exchange.Business.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ISerializer _serializer;
        private readonly ILogger<HttpClientService> _logger;
        public HttpClientService(HttpClient httpClient, 
            ISerializer serializer,
            ILogger<HttpClientService> logger)
        {
            _httpClient = new HttpClient();
            _serializer = serializer;
            _logger = logger;
        }
        public async Task<T> Get<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return _serializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HttpClientService::Get");
                throw;
            }

        }
    }
}
