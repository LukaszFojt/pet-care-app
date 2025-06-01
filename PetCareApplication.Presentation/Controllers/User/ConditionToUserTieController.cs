using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("conditionToUserTies")]
    [ApiController]
    public class ConditionToUserTieController : CommonCrudController<ConditionToUserTieEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConditionToUserTieController> _logger;

        public ConditionToUserTieController(IMediator mediator, ILogger<ConditionToUserTieController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

    }
}
