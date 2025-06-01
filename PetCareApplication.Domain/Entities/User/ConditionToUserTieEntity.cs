using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.User
{
    public class ConditionToUserTieEntity : DescNameIdEntity
    {
        public int ConditionId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
