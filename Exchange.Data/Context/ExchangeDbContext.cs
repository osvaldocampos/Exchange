using Exchange.Data.Interfaces;
using Exchange.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Exchange.Data.Context
{
    public class ExchangeDbContext : DbContext, IExchangeDbContext, IDisposable
    {
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLimit> UserLimits { get; set; }
        public DbSet<UserTransaction> UserTransactions { get; set; }

        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Any(type =>
                    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

