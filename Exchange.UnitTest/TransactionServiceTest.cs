using Exchange.Business.Interfaces;
using Exchange.Business.Models;
using Exchange.Business.Services;
using Exchange.Data.Context;
using Exchange.Data.Models;
using Exchange.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.UnitTest
{
    public class TransactionServiceTest
    {
        private readonly Mock<ICurrencyFactoryService> _mockCurrencyFactoryService;
        private readonly DbContextOptions<ExchangeDbContext> _dbContextOptions;
        private readonly Mock<ICurrencyService> _mockCurrencyService;
        private readonly ITransactionService _transactionService;
        private readonly ExchangeDbContext _exchangeDbContext;
        private readonly Mock<ILogger<TransactionService>> _mockLogger;

        public TransactionServiceTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ExchangeDbContext>()
                .UseInMemoryDatabase("EnrollmentDbContext")
                .Options;
            _exchangeDbContext = new ExchangeDbContext(_dbContextOptions);
            Seed(_exchangeDbContext);

            _mockCurrencyFactoryService = new Mock<ICurrencyFactoryService>();            
            _mockCurrencyService = new Mock<ICurrencyService>();
            _mockLogger = new Mock<ILogger<TransactionService>>();
            _transactionService = new TransactionService(_mockCurrencyFactoryService.Object, _exchangeDbContext, _mockLogger.Object);
        }

        [Fact]
        public async Task Service_ShouldReturnSuccess_WhenCallBuyAsync()
        {
            //Arrange
            int userId = 1;
            decimal baseCurrencyAmount = 450;
            decimal rate = 90;
            decimal convertedAmount = 50;
            var _currencyRate = new CurrencyRate() { Buy = rate };

            _mockCurrencyService.Setup(x => x.Convert(It.IsAny<decimal>()))
                .Returns(Task.FromResult(convertedAmount));
                
            _mockCurrencyFactoryService.Setup(x => x.GetCurrencyService(It.IsAny<CurrencyTypeEnum>()))
                .Returns(await Task.FromResult(_mockCurrencyService.Object));

            //Act
            var result = await _transactionService.BuyAsync(userId, baseCurrencyAmount, CurrencyTypeEnum.Dolar);

            //Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Service_ShouldReturnFail_WhenCallBuyAsync()
        {
            //Arrange
            int userId = 1;
            decimal baseCurrencyAmount = 450;
            decimal rate = 90;
            decimal convertedAmount = 1250;
            var _currencyRate = new CurrencyRate() { Buy = rate };

            _mockCurrencyService.Setup(x => x.Convert(It.IsAny<decimal>()))
                .Returns(Task.FromResult(convertedAmount));

            _mockCurrencyFactoryService.Setup(x => x.GetCurrencyService(It.IsAny<CurrencyTypeEnum>()))
                .Returns(await Task.FromResult(_mockCurrencyService.Object));

            //Act
            var result = await _transactionService.BuyAsync(userId, baseCurrencyAmount, CurrencyTypeEnum.Dolar);

            //Assert
            Assert.True(result.IsFailure);
        }

        private void Seed(ExchangeDbContext context) 
        {
            context.Users.AddRange(
                new User() { UserId = 1, Name = "Jhon" },
                new User() { UserId = 2, Name = "Joseph" }
                );

            context.Limits.AddRange(
                new Limit() { CurrencyTypeId = (int)CurrencyTypeEnum.Dolar, Amount = 1000 },
                new Limit() { CurrencyTypeId = (int)CurrencyTypeEnum.Real, Amount = 250 }
                );
            context.SaveChanges();
        }
          
    }
}
