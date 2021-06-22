using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;
using Exchange.Domain.Enums;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class CurrencyTypeConfiguration : IEntityTypeConfiguration<CurrencyType>
    {
        public void Configure(EntityTypeBuilder<CurrencyType> builder)
        {
            builder.HasKey(o => o.CurrencyTypeId);

            builder.HasData(new CurrencyType[] {
                new CurrencyType() { CurrencyTypeId = (int)CurrencyTypeEnum.Dolar, Name = "" },
                new CurrencyType() { CurrencyTypeId = (int)CurrencyTypeEnum.Real, Name = "" },
            });
        }
    }
}
