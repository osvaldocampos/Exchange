using Exchange.Business.Interfaces;
using Exchange.Business.Services.Concurrencies;
using Exchange.Domain.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Business.Services
{
    public class CurrencyFactoryService : ICurrencyFactoryService
    {
        private readonly IEnumerable<ICurrencyService> _currencyServices;
        private readonly ILogger<CurrencyFactoryService> _logger;
        public CurrencyFactoryService(IEnumerable<ICurrencyService> currencyServices,
            ILogger<CurrencyFactoryService> logger)
        {
            _currencyServices = currencyServices;
            _logger = logger;
        }

        public ICurrencyService GetCurrencyService(CurrencyTypeEnum currencyType)
        {
            try
            {
                switch (currencyType)
                {
                    case CurrencyTypeEnum.Dolar:
                        return _currencyServices.SingleOrDefault(x => x.GetType() == typeof(DolarCurrencyService));
                    case CurrencyTypeEnum.Real:
                        return _currencyServices.SingleOrDefault(x => x.GetType() == typeof(RealCurrencyService));
                    default:
                        throw new Exception("No currency service found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CurrencyFactoryService::GetCurrencyService");
                throw;
            }
        }
    }
}
