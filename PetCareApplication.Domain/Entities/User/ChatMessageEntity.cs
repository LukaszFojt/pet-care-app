using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.User
{
    public class ChatMessageEntity : DescNameIdEntity
    {
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public string SenderId { get; set; } = string.Empty;
        public string RecipientId { get; set; } = string.Empty;
        public List<ChatMessageRecipientEntity> Recipients { get; set; } = new();
    }
}
