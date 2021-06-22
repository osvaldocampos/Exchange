using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(o => o.TransactionId);

            builder.HasOne(t => t.CurrencyType);

            builder.HasOne(t => t.UserTransaction)
                .WithOne(t => t.Transaction);           
        }
    }
}
