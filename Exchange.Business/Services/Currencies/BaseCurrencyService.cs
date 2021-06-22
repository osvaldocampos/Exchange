using Exchange.Business.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Exchange.Business.Services.Concurrencies
{
    public abstract class BaseCurrencyService : ICurrencyService
    {
        private readonly ILogger<BaseCurrencyService> _logger;
        public BaseCurrencyService(ILogger<BaseCurrencyService> logger)
        {
            _logger = logger;
        }
        protected abstract Task<decimal> ConversionFactor();
        public async Task<decimal> Convert(decimal baseCurrencyAmount)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BaseCurrencyService::Convert");
                throw;
            }
            return baseCurrencyAmount / await ConversionFactor();
        }
    }
}
