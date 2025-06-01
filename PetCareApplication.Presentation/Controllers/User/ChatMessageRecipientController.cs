using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Presentation.Controllers.Common;

namespace PetCareApplication.Presentation.Controllers
{
    [Route("messageRecipient")]
    [ApiController]
    public class ChatMessageRecipientController : CommonCrudController<ChatMessageRecipientEntity>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChatMessageRecipientController> _logger;

        public ChatMessageRecipientController(IMediator mediator, ILogger<ChatMessageRecipientController> logger) : base(mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

    }
}
