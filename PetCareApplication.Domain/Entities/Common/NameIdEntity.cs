namespace PetCareApplication.Domain.Entities.Common
{
    public interface INameIdEntity : IIdEntity
    {
        string Name { get; }
    }
    public class NameIdEntity : IdEntity, INameIdEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
