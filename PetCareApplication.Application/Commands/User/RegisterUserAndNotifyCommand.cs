using MediatR;
using PetCareApplication.Application.Contracts.User;
using PetCareApplication.Domain.Entities.User;

namespace PetCareApplication.Application.Commands.User
{
    public class RegisterUserAndNotifyCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserAndNotifyCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class RegisterUserAndNotifyCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserAndNotifyCommand, bool>
    {
        public async Task<bool> Handle(RegisterUserAndNotifyCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.RegisterUserAndNotify(request.Email, request.Password);
        }
    }
}
