using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Queries.User
{
    public class GetUserInfoByUserIdQuery : IRequest<UserInfoEntity>
    {
        public string UserId { get; set; }

        public GetUserInfoByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetUserInfoByUserIdQueryHandler(
        IUserInfoRepository userInfoRepository
        ) : IRequestHandler<GetUserInfoByUserIdQuery, UserInfoEntity>
    {
        public async Task<UserInfoEntity?> Handle(GetUserInfoByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await userInfoRepository.GetUserInfoByUserId(request.UserId);
        }
    }
}
