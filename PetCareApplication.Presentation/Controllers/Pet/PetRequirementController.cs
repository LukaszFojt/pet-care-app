using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Domain.Entities.Pet;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Pet
{
    [Route("petRequirements")]
    [ApiController]
    public class PetRequirementController : CommonCrudController<PetRequirementEntity>
    {
        public PetRequirementController(IMediator mediator) : base(mediator)
        {

        }
    }
}
