using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Commands.Common
{
    public class DeleteEntityCommand<T> : IRequest<Unit> where T : class
    {
        public int Id { get; }

        public DeleteEntityCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteEntityCommandHandler<T> : IRequestHandler<DeleteEntityCommand<T>, Unit> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public DeleteEntityCommandHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Get(request.Id);
            if (entity != null)
            {
                await _repository.Delete(entity);
            }
            return Unit.Value;
        }
    }
}
