using FluentValidation;
using RiseAssessment.ContactService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Dtos
{
    public class ContactInformationDto
    {
        public ContactInformationDto(int contactInformationId, InformationType informationType, string informationContent, DateTime createdDate)
        {
            Id = contactInformationId;
            InformationContent = informationContent;
            InformationType = informationType;
            CreatedDate = createdDate;
        }
        public ContactInformationDto()
        {

        }
        public int Id { get; set; }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ContactInformationDtoValidator : AbstractValidator<ContactInformationDto>
    {
        public ContactInformationDtoValidator()
        {
            RuleFor(x => x.InformationContent).NotEmpty().WithMessage("Lütfen içerik giriniz.");
            RuleFor(x => x.InformationType).NotNull().WithMessage("Lütfen iletişim tipi giriniz.");
        }
    }
}
