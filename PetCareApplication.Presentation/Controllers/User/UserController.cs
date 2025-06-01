using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Commands.User;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.User;
using System.Security.Claims;

namespace PetCareApplication.Presentation.Controllers.User
{
    [Route("users")]
    [ApiController]
    public class UserController(IMediator mediator, ILogger<PostController> logger) : ControllerBase
    {
        [HttpGet("current")]
        [Authorize]
        public async Task<ActionResult<UserEntity>> GetCurrentUser()
        {
            string userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var currentUser = await mediator.Send(new GetCurrentUserQuery(userId));

            return Ok(currentUser);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<bool>> Logout()
        {
            var command = new LogoutUserCommand();
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("registerAndNotify")]
        public async Task<ActionResult<bool>> RegisterAndNotify([FromBody] RegisterUserAndNotifyCommand data)
        {
            var command = new RegisterUserAndNotifyCommand(data.Email, data.Password);
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
