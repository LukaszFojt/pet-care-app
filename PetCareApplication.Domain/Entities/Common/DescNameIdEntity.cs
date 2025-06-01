namespace PetCareApplication.Domain.Entities.Common
{
    public interface IDescNameIdEntity : INameIdEntity
    {
        string Description { get; set; }
    }
    public class DescNameIdEntity : NameIdEntity, IDescNameIdEntity
    {
        public string Description { get; set; } = string.Empty;
    }
}
