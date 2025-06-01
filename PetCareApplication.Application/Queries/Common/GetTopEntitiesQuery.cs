using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Queries.Common
{
    public class GetTopEntitiesQuery<T> : IRequest<List<T>>
    {
        public int _count { get; set; }
        public GetTopEntitiesQuery(int count)
        {
            _count = count;
        }
    }

    public class GetTopEntitiesQueryHandler<T> : IRequestHandler<GetTopEntitiesQuery<T>, List<T>> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public GetTopEntitiesQueryHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Handle(GetTopEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetTop(request._count);
        }
    }
}
