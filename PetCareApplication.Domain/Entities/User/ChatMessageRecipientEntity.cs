using PetCareApplication.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace PetCareApplication.Domain.Entities.User
{
    public class ChatMessageRecipientEntity : DescNameIdEntity
    {
        public int ChatMessageId { get; set; }
        [JsonIgnore] public ChatMessageEntity? ChatMessage { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public string RecipientId { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
    }
}
