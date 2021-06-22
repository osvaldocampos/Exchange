using System.Threading.Tasks;

namespace Exchange.Business.Interfaces
{
    public interface ICurrencyService
    {
        public Task<decimal> Convert(decimal baseCurrencyAmount);
    }
}