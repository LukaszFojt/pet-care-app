using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Domain.Entities.Structure;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Structure
{
    [Route("parameters")]
    [ApiController]
    public class ParameterController : CommonCrudController<ParameterEntity>
    {
        public ParameterController(IMediator mediator) : base(mediator)
        {

        }
    }
}
