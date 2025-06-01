using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Infrastructure.Configurations.Entities.Pet
{
    public class PetRequirementEntityConfiguration : IEntityTypeConfiguration<PetRequirementEntity>
    {
        public void Configure(EntityTypeBuilder<PetRequirementEntity> builder)
        {
            builder.ToTable("PetRequirements", "pet");

            builder.HasKey(pr => new { pr.PetId, pr.RequirementId });

            builder.HasOne(pr => pr.Pet)
                .WithMany(p => p.PetRequirements)
                .HasForeignKey(pr => pr.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pr => pr.Requirement)
                .WithMany(r => r.PetRequirements)
                .HasForeignKey(pr => pr.RequirementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}