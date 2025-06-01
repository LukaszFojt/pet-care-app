using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetOrdersByUserIdQuery : IRequest<List<OrderEntity>>
    {
        public string UserId { get; set; }

        public GetOrdersByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetOrdersByUserIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetOrdersByUserIdQuery, List<OrderEntity>>
    {
        public async Task<List<OrderEntity>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetOrdersByUserId(request.UserId);
        }
    }
}
