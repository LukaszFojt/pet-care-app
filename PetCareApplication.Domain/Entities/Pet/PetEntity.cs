using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Pet
{
    public class PetEntity : DescNameIdEntity
    {
        public float Age { get; set; }
        public Size Size { get; set; }
        public Sex Sex { get; set; }
        public List<PetRequirementEntity> PetRequirements { get; set; } = [];
        public string ImagePath { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }

    public enum Sex
    {
        Female = 0,
        Male = 1
    }

    public enum Size
    {
        Micro = 1,
        Small = 2,
        Mediocre = 3,
        Big = 4,
        Giant = 5
    }
}
