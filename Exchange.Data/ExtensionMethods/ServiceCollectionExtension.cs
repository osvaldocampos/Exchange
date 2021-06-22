using Exchange.Data.Context;
using Exchange.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exchange.Data.ExtensionMethods
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ExchangeDb");
            services.AddDbContext<ExchangeDbContext>();
            services.AddScoped(ctx =>
            {
                var options = new DbContextOptionsBuilder<ExchangeDbContext>()
                    .UseSqlServer(connectionString);

                return new ExchangeDbContext(options.Options);
            });

            services.AddScoped<IExchangeDbContext, ExchangeDbContext>(
                ctx => ctx.GetRequiredService<ExchangeDbContext>());

            return services;
        }
    }
}
