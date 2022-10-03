using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.ContactService.Domain.Models.Commands.ContactInformation;
using RiseAssessment.ContactService.Domain.Models.Results;
using Swashbuckle.AspNetCore.Annotations;

namespace RiseAssessment.ContactService.ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ContactInformationController : BaseApiController
    {
        public ContactInformationController(ILogger<ContactInformationController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Contact Information create işlemini gerçekleştirir")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult>> CreateContactInformation(CreateContactInformationCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Contact information delete işlemini gerçekleştirir")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult>> RemoveContactInformation(RemoveContactInformationCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
