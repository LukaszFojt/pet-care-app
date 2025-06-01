using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Structure
{
    public class ParameterEntity : DescNameIdEntity
    {
        public string Unit { get; set; } = string.Empty;
        public List<ProductParameterEntity> ProductParameters { get; set; } = [];
    }
}
