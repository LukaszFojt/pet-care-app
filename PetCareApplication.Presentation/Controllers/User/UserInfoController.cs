using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("userInfos")]
    [ApiController]
    public class UserInfoController : CommonCrudController<UserInfoEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserInfoController> _logger;

        public UserInfoController(IMediator mediator, ILogger<UserInfoController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<ActionResult<UserInfoEntity>> GetUserInfoByUserId(string userId)
        {
            try
            {
                var query = new GetUserInfoByUserIdQuery(userId);
                var userInfo = await _mediator.Send(query);

                if (userInfo == null)
                {
                    return NotFound("No user info found for the given user.");
                }

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "No user info found for the given user: {UserId}", userId);
                return StatusCode(500, $"Error occurred: {ex.Message}. Try again later");
            }
        }

        [HttpPut("updateByUserId/{userId}")]
        public async Task<ActionResult<UserInfoEntity>> UpdateUserInfoByUserId(string userId, [FromBody] UserInfoEntity data)
        {
            try
            {
                var query = new UpdateUserInfoByUserIdCommand(userId, data);
                var userInfo = await _mediator.Send(query);

                if (userInfo == null)
                {
                    return NotFound("No user info found for the given user.");
                }

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user info for: {UserId}", userId);
                return StatusCode(500, $"Error occurred: {ex.Message}. Try again later");
            }
        }
    }
}
