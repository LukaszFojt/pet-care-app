using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("conditions")]
    [ApiController]
    public class ConditionController : CommonCrudController<ConditionEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConditionController> _logger;

        public ConditionController(IMediator mediator, ILogger<ConditionController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

    }
}
