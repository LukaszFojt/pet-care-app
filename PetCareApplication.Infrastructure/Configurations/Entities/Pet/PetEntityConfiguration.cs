using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.Pet
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.ToTable("Pets", "pet");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.ImagePath).HasMaxLength(100);
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne<UserEntity>()
                .WithMany(user => user.Pets)
                .HasForeignKey(pet => pet.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
