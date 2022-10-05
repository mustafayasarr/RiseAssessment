using RiseAssessment.ReportService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Entities
{
    public class ReportItem : EntityBase<int>
    {
        public ReportItem(string? reportName,Status status)
        {
            ReportName = reportName;
            Status = status;
        }
        public string? ReportName { get; set; }
        public string? Path { get; set; }
        public string? RequestObjectJson { get; set; }
        public Status Status{ get; set; }
        public DateTime? ReportCreateDate { get; set; }
        public string? Message { get; set; }

    }
}
