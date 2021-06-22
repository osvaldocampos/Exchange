using Exchange.Business.Models;
using System.Threading.Tasks;

namespace Exchange.Business.Interfaces
{
    public interface IBancoProvinciaService
    {
        Task<CurrencyRate> GetDolarRate();
    }
}