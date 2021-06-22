using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Exchange.Business.Services.Concurrencies
{
    public class DolarCurrencyService : BaseCurrencyService
    {
        private IBancoProvinciaService _bancoProvinciaService;
        private readonly ILogger<DolarCurrencyService> _logger;
        public DolarCurrencyService(IBancoProvinciaService bancoProvinciaService,
            ILogger<DolarCurrencyService> logger) : base(logger)
        {
            _bancoProvinciaService = bancoProvinciaService;
            _logger = logger;
        }

        protected override async Task<decimal> ConversionFactor()
        {
            try
            {
                CurrencyRate currencyRate = await _bancoProvinciaService.GetDolarRate();
                return currencyRate.Buy;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DolarCurrencyService::ConversionFactor");
                throw;
            }

        }
    }
}
