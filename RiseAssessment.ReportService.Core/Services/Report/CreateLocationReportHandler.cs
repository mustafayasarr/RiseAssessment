using MediatR;
using Microsoft.Extensions.Logging;
using RiseAssessment.ReportService.Core.Gateways.ContactService;
using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;

namespace RiseAssessment.ReportService.Core.Services.Report
{
    public class CreateLocationReportHandler : IRequestHandler<CreateLocationReportCommand, BaseResponseResult<LocationReportResult>>
    {
        private readonly ILogger<CreateLocationReportHandler> _logger;
        private IContactGateway _contactGateway;
        public CreateLocationReportHandler(IContactGateway contactGateway, ILogger<CreateLocationReportHandler> logger)
        {
            _contactGateway = contactGateway;
            _logger = logger;
        }
        public async Task<BaseResponseResult<LocationReportResult>> Handle(CreateLocationReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<LocationReportResult>();
            try
            {
                response = await _contactGateway.CreateLocationReport(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add("Bir hata oluştu.");
            }
            return response;
        }
    }
}
