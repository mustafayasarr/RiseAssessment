using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Request
{
    public class CreateLocationReportRequest
    {
        public string ReportName { get; set; }
        public string? Location { get; set; }
    }
}
