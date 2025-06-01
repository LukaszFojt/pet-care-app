using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Pet
{
    public class RequirementEntity : DescNameIdEntity
    {
        public List<PetRequirementEntity> PetRequirements { get; set; } = [];
    }
}
