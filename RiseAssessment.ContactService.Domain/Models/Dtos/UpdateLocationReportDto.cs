using RiseAssessment.ContactService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Dtos
{
    public class UpdateLocationReportDto
    {
        public UpdateLocationReportDto()
        {
            ReportItems = new List<ReportItemDto>();
        }
        public int? Id { get; set; }
        public string? ReportName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<ReportItemDto> ReportItems { get; set; }
        public string? JsonRequest { get; set; }
        public Status Status { get; set; }
        public string? Message { get; set; }
    }
}
