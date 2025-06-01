using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetCurrentUserQuery : IRequest<UserEntity>
    {
        public string UserId { get; set; }

        public GetCurrentUserQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetCurrentUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetCurrentUserQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetCurrentUser(request.UserId);
        }
    }
}
