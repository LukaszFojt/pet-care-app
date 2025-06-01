using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.Structure
{
    public class ProductParameterEntity : DescNameIdEntity
    {
        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public int ParameterId { get; set; }
    }
}
