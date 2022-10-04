using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Core.Gateways.ContactService
{
    public interface IContactGateway
    {
        Task<BaseResponseResult<LocationReportResult>> CreateLocationReport(CreateLocationReportCommand request);
    }
}
