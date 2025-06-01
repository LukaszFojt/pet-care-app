using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Commands.Common
{
    public class AddEntityCommand<T> : IRequest<T>
    {
        public T Entity { get; }

        public AddEntityCommand(T entity)
        {
            Entity = entity;
        }
    }

    public class AddEntityCommandHandler<T> : IRequestHandler<AddEntityCommand<T>, T> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public AddEntityCommandHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(AddEntityCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.Add(request.Entity);
            return request.Entity;
        }
    }
}
