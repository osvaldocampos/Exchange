using Exchange.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Data.Interfaces
{
    public interface IExchangeDbContext
    {
        DbSet<CurrencyType> CurrencyTypes { get; set; }
        DbSet<Limit> Limits { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserLimit> UserLimits { get; set; }
        DbSet<UserTransaction> UserTransactions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}