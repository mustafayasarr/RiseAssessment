using MediatR;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;

namespace RiseAssessment.ContactService.Domain.Models.Commands.Report
{
    public class CreateLocationReportCommand : IRequest<BaseResponseResult<LocationReportResult>>
    {
        public CreateLocationReportCommand(string reportName, string location)
        {
            ReportName = reportName;
            Location = location;
        }
        public CreateLocationReportCommand()
        {

        }
        public string ReportName { get; set; }
        public string Location { get; set; }
    }
}
