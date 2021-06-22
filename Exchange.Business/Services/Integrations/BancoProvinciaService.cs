using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Exchange.Business.Services.Integration
{
    public class BancoProvinciaService : IBancoProvinciaService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly string _url;
        private readonly ILogger<BancoProvinciaService> _logger;
        public BancoProvinciaService(IHttpClientService httpClientService, 
            string url,
            ILogger<BancoProvinciaService> logger)
        {
            _httpClientService = httpClientService;
            _url = url;
            _logger = logger;
        }

        public async Task<CurrencyRate> GetDolarRate()
        {
            try
            {
                string[] result = await _httpClientService.Get<string[]>(_url);
                return new CurrencyRate()
                {
                    Buy = decimal.Parse(result[0]),
                    Sell = decimal.Parse(result[1])
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BancoProvinciaService::GetDolarRate");
                throw;
            }
        }
    }
}
