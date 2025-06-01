using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.User
{
    public class PostEntity : DescNameIdEntity
    {
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
