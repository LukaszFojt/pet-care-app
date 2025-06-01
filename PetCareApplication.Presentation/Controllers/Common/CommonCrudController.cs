using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Application.Commands.Common;
using PetCareApplication.Application.Queries.Common;

namespace PetCareApplication.Presentation.Controllers.Common
{
    [Route("[controller]")]
    [ApiController]
    public class CommonCrudController<T>(IMediator mediator) : ControllerBase where T : class
    {
        [HttpGet("getAll")]
        public async Task<ActionResult<List<T>>> Get()
        {
            var query = new GetAllEntitiesQuery<T>();
            var items = await mediator.Send(query);
            return Ok(items);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var query = new GetEntityByIdQuery<T>(id);
            var item = await mediator.Send(query);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("add")]
        public async Task<ActionResult<T>> Post([FromBody] T entity)
        {
            var command = new AddEntityCommand<T>(entity);
            var addedEntity = await mediator.Send(command);
            return Ok(addedEntity);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] T entity)
        {
            var command = new UpdateEntityCommand<T>(id, entity);
            var updatedEntity = await mediator.Send(command);
            return Ok(updatedEntity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEntityCommand<T>(id);
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("getTop")]
        public async Task<ActionResult<List<T>>> GetTop(int count)
        {
            var query = new GetTopEntitiesQuery<T>(count);
            var items = await mediator.Send(query);
            return Ok(items);
        }

        [HttpGet("getBot")]
        public async Task<ActionResult<List<T>>> GetBot(int count)
        {
            var query = new GetBotEntitiesQuery<T>(count);
            var items = await mediator.Send(query);
            return Ok(items);
        }

        [HttpPost("getFiltered")]
        public async Task<ActionResult<List<T>>> GetFiltered([FromBody] List<FilterParameter> filters)
        {
            var query = new GetFilteredEntitiesQuery<T>(filters);
            var items = await mediator.Send(query);
            return Ok(items);
        }
    }
}
