using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Queries.Common
{
    public class GetBotEntitiesQuery<T> : IRequest<List<T>>
    {
        public int _count { get; set; }
        public GetBotEntitiesQuery(int count)
        {
            _count = count;
        }
    }

    public class GetBotEntitiesQueryHandler<T> : IRequestHandler<GetBotEntitiesQuery<T>, List<T>> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public GetBotEntitiesQueryHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Handle(GetBotEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetBot(request._count);
        }
    }
}
