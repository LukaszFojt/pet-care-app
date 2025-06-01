using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetMessagesByUserIdQuery : IRequest<List<ChatMessageEntity>>
    {
        public string UserId { get; set; }

        public GetMessagesByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetMessagesByUserIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetMessagesByUserIdQuery, List<ChatMessageEntity>>
    {
        public async Task<List<ChatMessageEntity>> Handle(GetMessagesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetMessagesByUserId(request.UserId);
        }
    }
}
