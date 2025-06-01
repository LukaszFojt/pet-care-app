using MediatR;
using PetCareApplication.Application.Contracts.Common;

namespace PetCareApplication.Application.Commands.Common
{
    public class UpdateEntityCommand<T> : IRequest<T>
    {
        public int _id { get; set; }
        public T _entity { get; }

        public UpdateEntityCommand(int id, T entity)
        {
            _id = id;
            _entity = entity;
        }
    }

    public class UpdateEntityCommandHandler<T> : IRequestHandler<UpdateEntityCommand<T>, T> where T : class
    {
        private readonly ICommonCrudRepository<T> _repository;

        public UpdateEntityCommandHandler(ICommonCrudRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(UpdateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.Get(request._id);
            if (existingEntity == null)
            {
                return null;
            }

            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name == "Id")
                {
                    continue;
                }

                prop.SetValue(existingEntity, prop.GetValue(request._entity));
            }

            await _repository.Update(existingEntity);
            return existingEntity;
        }
    }
}
