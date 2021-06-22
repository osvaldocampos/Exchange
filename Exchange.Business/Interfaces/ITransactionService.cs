using Exchange.Business.Models;
using Exchange.Domain.DTOs;
using Exchange.Domain.Enums;
using System.Threading.Tasks;

namespace Exchange.Business.Interfaces
{
    public interface ITransactionService
    {
        Task<Result<TransactionDto>> BuyAsync(int userId, decimal baseCurrencyAmount, CurrencyTypeEnum currencyType);
    }
}