using System.Threading.Tasks;

namespace Exchange.Business.Interfaces
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(string url);
    }
}