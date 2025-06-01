using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.Structure;

namespace PetCareApplication.Infrastructure.Configurations.Entities.Structure
{
    public class ParameterEntityConfiguration : IEntityTypeConfiguration<ParameterEntity>
    {
        public void Configure(EntityTypeBuilder<ParameterEntity> builder)
        {
            builder.ToTable("Parameters", "structure");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100);
        }
    }
}
