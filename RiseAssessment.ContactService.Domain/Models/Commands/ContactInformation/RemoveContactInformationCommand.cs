using FluentValidation;
using MediatR;
using RiseAssessment.ContactService.Domain.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Commands.ContactInformation
{
    public class RemoveContactInformationCommand : IRequest<BaseResponseResult>
    {
        public string ContactId { get; set; }

        public int ContactInformationId { get; set; }
    }
    public class RemoveContactInformationCommandValidator : AbstractValidator<RemoveContactInformationCommand>
    {
        public RemoveContactInformationCommandValidator()
        {
            RuleFor(x => x.ContactId)
                .NotEmpty().WithMessage("Lütfen information type giriniz.");
            RuleFor(x => x.ContactInformationId).NotEmpty().WithMessage("Lütfen contact id giriniz.").GreaterThan(0).WithMessage("Lütfen contact id giriniz.");
        }
    }
}
