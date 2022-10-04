using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiseAssessment.ReportService.Domain.Models.Results;
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

   
    }
}
