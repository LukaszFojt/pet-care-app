using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.User
{
    public class ConditionToUserTieEntityConfiguration : IEntityTypeConfiguration<ConditionToUserTieEntity>
    {
        public void Configure(EntityTypeBuilder<ConditionToUserTieEntity> builder)
        {
            builder.ToTable("ConditionToUserTies", "user");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
}
