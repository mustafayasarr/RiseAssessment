using MediatR;
using RiseAssessment.ReportService.Domain.Models.Dtos;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Commands
{
    public class UpdateLocationReportCommand : IRequest<BaseResponseResult>
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ReportItemDto> ReportItems { get; set; }
    }
}
