using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

public class UpdateUserInfoByUserIdCommand : IRequest<UserInfoEntity>
{
    public string UserId { get; set; }
    public UserInfoEntity UserInfo { get; set; }

    public UpdateUserInfoByUserIdCommand(string userId, UserInfoEntity userInfo)
    {
        UserId = userId;
        UserInfo = userInfo;
    }
}

public class UpdateUserInfoByUserIdCommandHandler(
    IUserInfoRepository userInfoRepository
    ) : IRequestHandler<UpdateUserInfoByUserIdCommand, UserInfoEntity>
{
    public async Task<UserInfoEntity?> Handle(UpdateUserInfoByUserIdCommand request, CancellationToken cancellationToken)
    {
        return await userInfoRepository.UpdateUserInfoByUserId(request.UserId, request.UserInfo);
    }
}