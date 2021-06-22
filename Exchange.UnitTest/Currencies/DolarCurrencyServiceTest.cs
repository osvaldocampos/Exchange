using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Exchange.Business.Services.Concurrencies;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.UnitTest.Currencies
{
    public class DolarCurrencyServiceTest
    {
        private readonly Mock<IBancoProvinciaService> _mockBancoProvinciaService;
        private readonly ICurrencyService _dolarCurrencyService;
        private readonly Mock<ILogger<DolarCurrencyService>> _mockLogger;
        private CurrencyRate _currencyRate;
        public DolarCurrencyServiceTest()
        {
            _mockBancoProvinciaService = new Mock<IBancoProvinciaService>();
            _mockLogger = new Mock<ILogger<DolarCurrencyService>>();
            _dolarCurrencyService = new DolarCurrencyService(_mockBancoProvinciaService.Object, _mockLogger.Object);
        }
        
        [Fact]
        public async Task Service_ShouldGetConversionFactor_WhenCallConversionFactor()
        {
            //Arrange
            decimal rate = 92;
            decimal amount = 50;
            _currencyRate = new CurrencyRate() { Buy = rate };
            _mockBancoProvinciaService.Setup(x => x.GetDolarRate())
                .Returns(Task.FromResult(_currencyRate));

            //Act
            var result = await _dolarCurrencyService.Convert(amount);

            //Assert
            Assert.Equal(result, amount / rate);
        }
    }
}
