using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Queries;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;
using Swashbuckle.AspNetCore.Annotations;

namespace RiseAssessment.ReportService.ReportAPI.Controllers
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
        [SwaggerOperation(Summary = "Lokasyona göre raporlama getirir.")]
        [ProducesResponseType(typeof(BaseResponseResult<LocationReportResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult<LocationReportResult>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult<LocationReportResult>>> CreateLocationReport(CreateLocationReportCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpGet]
        [SwaggerOperation(Summary = "Rapor Listeleme")]
        [ProducesResponseType(typeof(BaseResponseResult<GetReportResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult<GetReportResult>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult<List<GetReportResult>>>> GetListReport([FromQuery]GetListReportQuery query)
        {
            var response = await _mediator.Send(query);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }
        [HttpPost]
        [SwaggerOperation(Summary = "Rapor Ekleme")]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseResult>> UpdateReport(UpdateLocationReportCommand query)
        {
            var response = await _mediator.Send(query);

            if (response.HasError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }


    }
}
