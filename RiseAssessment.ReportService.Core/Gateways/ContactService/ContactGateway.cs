using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RiseAssessment.ReportService.Core.Gateways;
using RiseAssessment.ReportService.Domain.Constants;
using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;

namespace RiseAssessment.ReportService.Core.Gateways.ContactService
{
    public class ContactGateway : BaseService, IContactGateway
    {
        public ContactGateway(IRestService restService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(restService, httpContextAccessor)
        {
            BaseAddress = configuration["ServiceUrls:ContactService"];
        }

        public async Task<BaseResponseResult<LocationReportResult>> CreateLocationReport(CreateLocationReportCommand request)
        {
            return await _restService.PostMethodAsync<BaseResponseResult<LocationReportResult>>(request, BaseAddress + GatewayUrls.CreateLocationReport);
        }

    }
}
