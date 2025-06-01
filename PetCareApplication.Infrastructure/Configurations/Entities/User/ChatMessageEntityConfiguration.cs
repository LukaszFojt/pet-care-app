using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.User
{
    public class ChatMessageEntityConfiguration : IEntityTypeConfiguration<ChatMessageEntity>
    {
        public void Configure(EntityTypeBuilder<ChatMessageEntity> builder)
        {
            builder.ToTable("ChatMessages", "user");

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.SentAt).IsRequired();

            builder.HasIndex(cm => cm.SenderId);

            builder.HasMany(cm => cm.Recipients)
                .WithOne(cr => cr.ChatMessage)
                .HasForeignKey(cr => cr.ChatMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
