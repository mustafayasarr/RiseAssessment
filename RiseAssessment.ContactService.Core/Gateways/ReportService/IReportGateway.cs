using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Dtos;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;

namespace RiseAssessment.ContactService.Core.Gateways.ContactService
{
    public interface IReportGateway
    {
        Task<BaseResponseResult> UpdateReport(UpdateLocationReportDto request);
    }
}
