using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Structure
{
    public class ProductEntity : DescNameIdEntity
    {
        public List<ProductParameterEntity> ProductParameters { get; set; } = [];
    }
}
