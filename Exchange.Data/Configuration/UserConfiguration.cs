using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchange.Data.Models;

namespace Scholar.Data.Configuration.EntidadesInstitucion
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {            
            builder.HasKey(o => o.UserId);

            builder.HasMany(x => x.UserTransactions)
                .WithOne(x => x.User);

            builder.HasData(
                new User() { UserId = 1, Name = "Jhon" },
                new User() { UserId = 2, Name = "Terri" }
                );
        }
    }
}
