using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.User
{
    public class ConditionEntityConfiguration : IEntityTypeConfiguration<ConditionEntity>
    {
        public void Configure(EntityTypeBuilder<ConditionEntity> builder)
        {
            builder.ToTable("Conditions", "user");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
}
