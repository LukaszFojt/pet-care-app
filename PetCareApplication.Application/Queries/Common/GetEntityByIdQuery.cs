using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Queries.Common
{
    public class GetEntityByIdQuery<T> : IRequest<T>
    {
        public int _id { get; set; }
        public GetEntityByIdQuery(int id)
        {
            _id = id;
        }
    }

    public class GetEntityByIdQueryHandler<T> : IRequestHandler<GetEntityByIdQuery<T>, T> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public GetEntityByIdQueryHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> Handle(GetEntityByIdQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request._id);
        }
    }
}
