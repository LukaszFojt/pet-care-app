using MediatR;
using PetCareApplication.Application.Contracts.User;

namespace PetCareApplication.Application.Commands.User
{
    public class LogoutUserCommand : IRequest<bool>
    {
    }

    public class LogoutUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LogoutUserCommand, bool>
    {
        public async Task<bool> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.LogoutUser();
        }
    }
}
