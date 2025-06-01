using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Domain.Entities.Structure;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Structure
{
    [Route("productParameters")]
    [ApiController]
    public class ProductParameterController : CommonCrudController<ProductParameterEntity>
    {
        public ProductParameterController(IMediator mediator) : base(mediator)
        {

        }
    }
}
