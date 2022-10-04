using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;
using Swashbuckle.AspNetCore.Annotations;

namespace RiseAssessment.ContactService.ContactAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class ReportController : BaseApiController
    {
        public ReportController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Contact Information create işlemini gerçekleştirir")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult<LocationReportResult>>> CreateLocationReport(CreateLocationReportCommand command)
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
