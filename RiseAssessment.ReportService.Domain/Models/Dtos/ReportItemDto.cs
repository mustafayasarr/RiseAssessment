using RiseAssessment.ReportService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Domain.Models.Dtos
{
    public class ReportItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
