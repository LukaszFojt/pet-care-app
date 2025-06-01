using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Application.Commands.Pet;
using PetCareApplication.Application.Queries.Pet;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Pet
{
    [Route("pets")]
    [ApiController]
    public class PetController : CommonCrudController<PetEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PetController> _logger;

        public PetController(IMediator mediator, ILogger<PetController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("allByUserId/{userId}")]
        public async Task<ActionResult<List<PetEntity>>> GetPetsByUserId(string userId)
        {
            var query = new GetPetsByUserIdQuery(userId);
            var pets = await _mediator.Send(query);

            if (pets == null || pets.Count == 0)
            {
                return NotFound("No pets found for the given user.");
            }

            return Ok(pets);
        }

        [HttpPost("addPetWithImage")]
        public async Task<ActionResult<PetEntity>> AddPetWithImage(
            [FromForm] AddPetWithImageCommand command)
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

        [HttpPut("updatePetWithImage")]
        public async Task<ActionResult<PetEntity>> UpdatePetWithImage(
            [FromForm] UpdatePetWithImageCommand command)
        {
            try
            {
                var post = await _mediator.Send(command);
                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating post with image.");
                return StatusCode(500, "Error occured. Try again later" + ex.Message);
            }
        }
    }
}
