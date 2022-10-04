﻿using RiseAssessment.ContactService.Domain.Models.Enums;

namespace RiseAssessment.ContactService.Domain.Models.Dtos
{
    public class ReportItemDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
