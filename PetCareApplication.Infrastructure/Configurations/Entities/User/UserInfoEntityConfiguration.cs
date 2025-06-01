using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.User
{
    public class UserInfoEntityConfiguration : IEntityTypeConfiguration<UserInfoEntity>
    {
        public void Configure(EntityTypeBuilder<UserInfoEntity> builder)
        {
            builder.ToTable("UserInfos", "user");

            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Initials).HasMaxLength(5);
            builder.Property(p => p.Street).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(100);
            builder.Property(p => p.Region).HasMaxLength(100);
            builder.Property(p => p.PostalCode).HasMaxLength(20);
            builder.Property(p => p.Country).HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);

            builder.HasOne<UserEntity>()
                .WithOne(us => us.UserInfo)
                .HasForeignKey<UserInfoEntity>(ui => ui.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

