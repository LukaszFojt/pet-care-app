using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Pet
{
    [Route("requirements")]
    [ApiController]
    public class RequirementController : CommonCrudController<RequirementEntity>
    {
        public RequirementController(IMediator mediator) : base(mediator)
        {

        }
    }
}
