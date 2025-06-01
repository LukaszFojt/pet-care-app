using Microsoft.AspNetCore.Identity;
using PetCareApplication.Domain.Entities.Pet;

namespace PetCareApplication.Domain.Entities.User
{
    public class UserEntity : IdentityUser
    {
        public UserInfoEntity UserInfo { get; set; } = new UserInfoEntity();
        public List<PostEntity> Posts { get; set; } = [];
        public List<PetEntity> Pets { get; set; } = [];
        public List<OrderEntity> Orders { get; set; } = [];
        public List<ConditionEntity> Conditions { get; set; } = [];
        public List<ChatMessageEntity> SentMessages { get; set; } = [];
        public List<ChatMessageRecipientEntity> ReceivedMessages { get; set; } = [];
    }
}
