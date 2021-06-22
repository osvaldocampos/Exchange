using Exchange.Business.Interfaces;
using Exchange.Business.Services;
using Exchange.Business.Services.Concurrencies;
using Exchange.Business.Services.Integration;
using Exchange.Business.Services.Serializers;
using Exchange.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Exchange.Business.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterBusiness(this IServiceCollection services)
        {
            #region Mappers
            #endregion

            #region Services
            services
                .AddScoped<HttpClient>()
                .AddScoped<ICurrencyService, DolarCurrencyService>()
                .AddScoped<ICurrencyService, RealCurrencyService>()
                .AddScoped<IBancoProvinciaService>(ctx => 
                    new BancoProvinciaService(
                        new HttpClientService(ctx.GetRequiredService<HttpClient>(), new JsonSerializer(), ctx.GetRequiredService<ILogger<HttpClientService>>()), 
                        ctx.GetRequiredService<AppSettings>().BancoProvinciaUrl, ctx.GetRequiredService<ILogger<BancoProvinciaService>>()))
                .AddScoped<ICurrencyFactoryService, CurrencyFactoryService>()
                .AddScoped<IHttpClientService, HttpClientService>()
                .AddScoped<ISerializer, JsonSerializer>()
                .AddScoped<ITransactionService, TransactionService>();
            #endregion

            return services;
        }

    }
}
