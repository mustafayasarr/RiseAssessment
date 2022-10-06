using MediatR;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;

namespace RiseAssessment.ReportService.Domain.Models.Commands
{
    public class CreateLocationReportCommand : IRequest<BaseResponseResult>
    {
        public CreateLocationReportCommand(int id,string reportName, string location)
        {
            ReportName = reportName;
            Location = location;
        }
        public CreateLocationReportCommand()
        {

        }
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string? Location { get; set; }

    }
}
