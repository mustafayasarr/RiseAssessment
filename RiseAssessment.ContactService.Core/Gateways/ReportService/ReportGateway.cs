using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Dtos;
using RiseAssessment.ContactService.Domain.Models.Results;

namespace RiseAssessment.ContactService.Core.Gateways.ContactService
{
    public class ReportGateway : BaseService, IReportGateway
    {
        public ReportGateway(IRestService restService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(restService, httpContextAccessor)
        {
            BaseAddress = configuration["ServiceUrls:ReportService"];
        }

        public async Task<BaseResponseResult> UpdateReport(UpdateLocationReportDto request)
        {
            return await _restService.PostMethodAsync<BaseResponseResult>(request, BaseAddress + GatewayUrls.UpdateReport);
        }

    }
}
