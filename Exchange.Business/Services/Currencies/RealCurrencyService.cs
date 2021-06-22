using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Exchange.Business.Services.Concurrencies
{
    public class RealCurrencyService : BaseCurrencyService
    {
        private IBancoProvinciaService _bancoProvinciaService;
        private readonly ILogger<RealCurrencyService> _logger;
        public RealCurrencyService(IBancoProvinciaService bancoProvinciaService,
            ILogger<RealCurrencyService> logger) : base(logger)
        {
            _bancoProvinciaService = bancoProvinciaService;
            _logger = logger;
        }

        protected override async Task<decimal> ConversionFactor()
        {
            try
            {
                CurrencyRate currencyRate = await _bancoProvinciaService.GetDolarRate();
                return currencyRate.Buy / 4;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RealCurrencyService::ConversionFactor");
                throw;
            }

        }
    }
}
