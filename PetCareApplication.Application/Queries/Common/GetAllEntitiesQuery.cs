using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Queries.Common
{
    public class GetAllEntitiesQuery<T> : IRequest<List<T>>
    {

    }

    public class GetAllEntitiesQueryHandler<T> : IRequestHandler<GetAllEntitiesQuery<T>, List<T>> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public GetAllEntitiesQueryHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Handle(GetAllEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
