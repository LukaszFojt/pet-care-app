using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Infrastructure.Configurations.Entities.Pet
{
    public class RequirementEntityConfiguration : IEntityTypeConfiguration<RequirementEntity>
    {
        public void Configure(EntityTypeBuilder<RequirementEntity> builder)
        {
            builder.ToTable("Requirements", "pet");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
        }
    }
}
