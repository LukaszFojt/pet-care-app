using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.Structure;

namespace PetCareApplication.Infrastructure.Configurations.Entities.Structure
{
    public class ProductParameterEntityConfiguration : IEntityTypeConfiguration<ProductParameterEntity>
    {
        public void Configure(EntityTypeBuilder<ProductParameterEntity> builder)
        {
            builder.ToTable("ProductParameters", "structure");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100);

            builder.HasOne<ProductEntity>()
                .WithMany(prod => prod.ProductParameters)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ParameterEntity>()
                .WithMany(param => param.ProductParameters)
                .HasForeignKey(pp => pp.ParameterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
