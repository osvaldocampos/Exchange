using Exchange.Business.Interfaces;
using Exchange.Data.Interfaces;
using Exchange.Domain.Enums;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exchange.Data.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Exchange.Business.Models;
using System.Net;
using Microsoft.Extensions.Logging;
using Exchange.Domain.DTOs;

namespace Exchange.Business.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ICurrencyFactoryService _currencyFactoryService;
        private readonly IExchangeDbContext _exchangeDbContext;
        private ICurrencyService _currencyService;
        private readonly ILogger<TransactionService> _logger;
        public TransactionService(ICurrencyFactoryService currencyFactoryService, 
            IExchangeDbContext exchangeDbContext,
            ILogger<TransactionService> logger)
        {
            _currencyFactoryService = currencyFactoryService;
            _exchangeDbContext = exchangeDbContext;
            _logger = logger;
        }

        public async Task<Result<TransactionDto>> BuyAsync(int userId, decimal baseCurrencyAmount, CurrencyTypeEnum currencyType)
        {
            try
            {
                _currencyService = _currencyFactoryService.GetCurrencyService(currencyType);
                decimal amount = await _currencyService.Convert(baseCurrencyAmount);

                Result result = await ValidateBuyRequest(userId, currencyType, amount);

                if (result.IsFailure)
                {                    
                    return Result<TransactionDto>.Fail(result.HttpStatus, result.Message);
                }

                var userTransaction = new UserTransaction()
                {
                    UserId = userId,
                    Transaction = new Transaction()
                    {
                        Amount = amount,
                        CurrencyTypeId = (int)currencyType,
                        DateTime = DateTime.Now
                    }
                };

                await _exchangeDbContext.UserTransactions.AddAsync(userTransaction);

                await _exchangeDbContext.SaveChangesAsync();

                //TODO: Use AutoMapper
                var dto = new TransactionDto()
                {
                    TransactionId = userTransaction.Transaction.TransactionId,
                    Amount = userTransaction.Transaction.Amount,
                    CurrencyTypeId = userTransaction.Transaction.CurrencyTypeId,
                    DateTime = userTransaction.Transaction.DateTime,
                };

                return Result<TransactionDto>.Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TransactionServiceTransactionService::BuyAsync");
                throw;
            }
        }

        private async Task<Result> ValidateBuyRequest(int userId, CurrencyTypeEnum currencyTypeEnum, decimal amount)
        {
            try
            {
                Limit limit = await _exchangeDbContext.Limits
                    .SingleOrDefaultAsync(x => x.CurrencyTypeId == (int)currencyTypeEnum);

                decimal totalAmount = await _exchangeDbContext.Transactions
                    .Include(x => x.UserTransaction)
                    .Where(x => x.UserTransaction.UserId == userId && x.DateTime.Month == DateTime.Now.Month)
                    .Select(x => x.Amount)
                    .SumAsync();

                if (totalAmount + amount > limit.Amount)
                {
                    return Result.Fail(HttpStatusCode.Forbidden, $"The maximum purchase amount has been reached for the currency type: { currencyTypeEnum }");
                }

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TransactionService::ValidateBuyRequest");
                throw;
            }
        }
    }
}
