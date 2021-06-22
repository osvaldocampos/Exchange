using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Exchange.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExchangeDbContext>
    {
        public ExchangeDbContext CreateDbContext(string[] args)
        {
           
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)
                .AddJsonFile("Exchange.Api/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ExchangeDbContext>();

            var connectionString = configuration.GetConnectionString("ExchangeDb");

            builder.UseSqlServer(connectionString);

            return new ExchangeDbContext(builder.Options);
        }
    }
}
