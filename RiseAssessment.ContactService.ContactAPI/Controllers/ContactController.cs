using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.ContactService.Domain.Models.Commands.Contact;
using RiseAssessment.ContactService.Domain.Models.Queries.Contact;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Contact;
using Swashbuckle.AspNetCore.Annotations;

namespace RiseAssessment.ContactService.ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ContactController : BaseApiController
    {
        public ContactController(ILogger<ContactController> logger, IMediator mediator) : base(logger, mediator)
        {
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Contact create işlemini gerçekleştirir")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult>> CreateContact(CreateContactCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }


        [HttpPost]
        [SwaggerOperation(Summary = "Contact delete işlemini gerçekleştirir")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult>> RemoveContact(RemoveContactCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }



        [HttpGet]
        [SwaggerOperation(Summary = "Contact Listesi getirir")]
        [ProducesResponseType(typeof(BaseResponseResult<List<GetAllContactResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult<List<GetAllContactResult>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult<List<GetAllContactResult>>>> GetListContact()
        {
            var response = await _mediator.Send(new GetAllContactQuery());

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Contact bilgisi getirir")]
        [ProducesResponseType(typeof(BaseResponseResult<GetContactResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult<GetContactResult>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult<GetContactResult>>> GetContact(string contactId)
        {
            var response = await _mediator.Send(new GetContactQuery(contactId));

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
