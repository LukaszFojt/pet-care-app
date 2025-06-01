using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareApplication.Domain.Entities.Structure;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers.Structure
{
    [Route("products")]
    [ApiController]
    public class ProductController : CommonCrudController<ProductEntity>
    {
        public ProductController(IMediator mediator) : base(mediator)
        {

        }
    }
}
