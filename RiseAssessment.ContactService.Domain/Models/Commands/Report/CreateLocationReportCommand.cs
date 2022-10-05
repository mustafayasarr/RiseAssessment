using MediatR;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;

namespace RiseAssessment.ContactService.Domain.Models.Commands.Report
{
    public class CreateLocationReportCommand : IRequest<BaseResponseResult<LocationReportResult>>
    {
        public CreateLocationReportCommand(int? id,string? reportName, string? location)
        {
            Id = id;
            ReportName = reportName;
            Location = location;
        }
        public CreateLocationReportCommand()
        {

        }
        public int? Id { get; set; }
        public string? ReportName { get; set; }
        public string? Location { get; set; }
    }
}
