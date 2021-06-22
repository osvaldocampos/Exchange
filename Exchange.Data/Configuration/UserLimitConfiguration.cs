using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class UserLimitConfiguration : IEntityTypeConfiguration<UserLimit>
    {
        public void Configure(EntityTypeBuilder<UserLimit> builder)
        {            
            builder.HasKey(o => new { o.UserId, o.LimitId });

            builder.HasData(
                new UserLimit() { UserId = 1, LimitId = 1 },
                new UserLimit() { UserId = 1, LimitId = 2 },
                new UserLimit() { UserId = 2, LimitId = 3 },
                new UserLimit() { UserId = 2, LimitId = 4 }
                );
        }
    }
}
