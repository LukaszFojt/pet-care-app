using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Commands.User;
using PetCareApplication.Application.Queries.User;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostController : CommonCrudController<PostEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PostController> _logger;

        public PostController(IMediator mediator, ILogger<PostController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allByUserId/{userId}")]
        public async Task<ActionResult<List<PostEntity>>> GetPostsByUserId(string userId)
        {
            try
            {
                var query = new GetPostsByUserIdQuery(userId);
                var posts = await _mediator.Send(query);

                if (posts == null || posts.Count == 0)
                {
                    return NotFound("No posts found for the given user.");
                }

                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "No posts found for the given user: {UserId}", userId);
                return StatusCode(500, "Error occured. Try again later");
            }
        }

        [HttpPost("addPostWithImage")]
        public async Task<ActionResult<PostEntity>> AddPostWithImage(
            [FromForm] AddPostWithImageCommand command)
        {
            try
            {
                var post = await _mediator.Send(command);
                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding post with image.");
                return StatusCode(500, "Error occured. Try again later");
            }
        }

        [HttpPut("updatePostWithImage")]
        public async Task<ActionResult<PostEntity>> UpdatePostWithImage(
            [FromForm] UpdatePostWithImageCommand command)
        {
            try
            {
                var post = await _mediator.Send(command);
                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating post with image.");
                return StatusCode(500, "Error occured. Try again later");
            }
        }
    }
}
