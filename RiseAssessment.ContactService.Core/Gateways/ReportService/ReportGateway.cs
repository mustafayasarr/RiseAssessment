using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;

namespace RiseAssessment.ContactService.Core.Gateways.ContactService
{
    public class ReportGateway : BaseService, IReportGateway
    {
        public ReportGateway(IRestService restService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(restService, httpContextAccessor)
        {
            BaseAddress = configuration["ServiceUrls:ReportService"];
        }

        public async Task<BaseResponseResult> UpdateReport(LocationReportResult request)
        {
            return await _restService.PostMethodAsync<BaseResponseResult>(request, BaseAddress + GatewayUrls.UpdateReport);
        }

    }
}
