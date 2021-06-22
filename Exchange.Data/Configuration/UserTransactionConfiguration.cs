using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class UserTransactionConfiguration : IEntityTypeConfiguration<UserTransaction>
    {
        public void Configure(EntityTypeBuilder<UserTransaction> builder)
        {            
            builder.HasKey(o => new { o.UserId, o.TransactionId });
        }
    }
}
