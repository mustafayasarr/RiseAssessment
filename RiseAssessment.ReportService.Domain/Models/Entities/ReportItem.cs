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
        public ReportItem(Status status)
        {
            Status = status;
        }
        public string? Path { get; set; }
        public  Status Status{ get; set; }
    }
}
