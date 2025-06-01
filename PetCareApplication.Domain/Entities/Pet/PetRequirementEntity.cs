using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Pet
{
    public class PetRequirementEntity : DescNameIdEntity
    {
        public int PetId { get; set; }
        public PetEntity Pet { get; set; } = null!;
        public int RequirementId { get; set; }
        public RequirementEntity Requirement { get; set; } = null!;
    }
}
