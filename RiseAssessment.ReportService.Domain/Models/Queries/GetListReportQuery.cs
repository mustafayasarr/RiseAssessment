using MediatR;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Queries
{
    public class GetListReportQuery : IRequest<BaseResponseResult<List<GetReportResult>>>
    {
    }
}
