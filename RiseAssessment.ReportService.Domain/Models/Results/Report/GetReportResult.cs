using RiseAssessment.ReportService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Results.Report
{
    public class GetReportResult
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
