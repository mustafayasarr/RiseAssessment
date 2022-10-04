using RiseAssessment.ContactService.Domain.Models.Enums;

namespace RiseAssessment.ContactService.Domain.Models.Dtos
{
    public class ReportItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
