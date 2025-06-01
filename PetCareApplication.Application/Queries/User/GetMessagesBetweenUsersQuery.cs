using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetMessagesBetweenUsersQuery : IRequest<List<ChatMessageEntity>>
    {
        public string SenderId { get; set; }
        public string RecipientId { get; set; }

        public GetMessagesBetweenUsersQuery(string senderId, string recipientId)
        {
            SenderId = senderId;
            RecipientId = recipientId;
        }
    }

    public class GetMessagesBetweenUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetMessagesBetweenUsersQuery, List<ChatMessageEntity>>
    {
        public async Task<List<ChatMessageEntity>> Handle(GetMessagesBetweenUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetMessagesBetweenUsers(request.SenderId, request.RecipientId);
        }
    }
}
