using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Queries.Common
{
    public class FilterParameter
    {
        public string FilterName { get; set; } = string.Empty;
        public object FilterValue { get; set; } = string.Empty;
    }

    public class GetFilteredEntitiesQuery<T> : IRequest<List<T>>
    {
        public List<FilterParameter> Filters { get; set; } = new();

        public GetFilteredEntitiesQuery(List<FilterParameter> filters)
        {
            Filters = filters;
        }
    }

    public class GetFilteredEntitiesQueryHandler<T> : IRequestHandler<GetFilteredEntitiesQuery<T>, List<T>> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public GetFilteredEntitiesQueryHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Handle(GetFilteredEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetFiltered(request.Filters);
        }
    }
}
