namespace PetCareApplication.Domain.Entities.Common
{
    public interface IIdEntity
    {
        int Id { get; set; }
    }
    public abstract class IdEntity : IIdEntity
    {
        public int Id { get; set; }
    }
}
