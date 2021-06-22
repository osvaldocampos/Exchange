using Exchange.Domain.Enums;

namespace Exchange.Business.Interfaces
{
    public interface ICurrencyFactoryService
    {
        ICurrencyService GetCurrencyService(CurrencyTypeEnum currencyType);
    }
}