using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Infrastructure.Configurations.Entities.User
{
    public class ChatMessageRecipientEntityConfiguration : IEntityTypeConfiguration<ChatMessageRecipientEntity>
    {
        public void Configure(EntityTypeBuilder<ChatMessageRecipientEntity> builder)
        {
            builder.ToTable("ChatMessageRecipients", "user");

            builder.HasKey(cr => new { cr.ChatMessageId, cr.RecipientId });

            builder.HasIndex(cr => cr.RecipientId);

            builder.HasOne(cr => cr.ChatMessage)
                .WithMany(cm => cm.Recipients)
                .HasForeignKey(cr => cr.ChatMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
