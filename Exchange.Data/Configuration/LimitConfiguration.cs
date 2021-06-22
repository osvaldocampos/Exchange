using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;
using Exchange.Domain.Enums;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class LimitConfiguration : IEntityTypeConfiguration<Limit>
    {
        public void Configure(EntityTypeBuilder<Limit> builder)
        {
            builder.HasKey(o => o.LimitId);

            builder.HasOne(t => t.UserLimit)
                .WithOne(t => t.Limit);

            builder.HasOne(t => t.CurrencyType);

            builder.HasData(
                new Limit() { LimitId = 1, CurrencyTypeId = (int)CurrencyTypeEnum.Dolar, Amount = 1000 },
                new Limit() { LimitId = 2, CurrencyTypeId = (int)CurrencyTypeEnum.Real, Amount = 250 },
                new Limit() { LimitId = 3, CurrencyTypeId = (int)CurrencyTypeEnum.Dolar, Amount = 1000 },
                new Limit() { LimitId = 4, CurrencyTypeId = (int)CurrencyTypeEnum.Real, Amount = 250 }
                );
        }
    }
}
