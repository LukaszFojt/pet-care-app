using PetCareApplication.Application.Queries.Common;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Contracts.Common;

public interface IFilterHandler<T>
{
    Task<List<T>> ApplyFiltersAsync(IQueryable<T> query, List<FilterParameter> filters, IQueryable<ConditionToUserTieEntity> conditionToUserTiesQuery);
}
