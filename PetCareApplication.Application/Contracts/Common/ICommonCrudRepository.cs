using PetCareApplication.Application.Queries.Common;

namespace PetCareApplication.Application.Contracts.Common
{
    public interface ICommonCrudRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<List<T>> GetTop(int count);
        Task<List<T>> GetBot(int count);
        Task<List<T>> GetFiltered(List<FilterParameter> filters);
    }
}
