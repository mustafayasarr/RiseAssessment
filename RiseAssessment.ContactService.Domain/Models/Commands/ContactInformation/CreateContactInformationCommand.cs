using MediatR;
using RiseAssessment.ContactService.Domain.Models.Enums;
using RiseAssessment.ContactService.Domain.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Commands.ContactInformation
{
    public class CreateContactInformationCommand : IRequest<BaseResponseResult>
    {
        public CreateContactInformationCommand(InformationType informationType, string informationContent, string contactId)
        {
            InformationType = informationType;
            InformationContent = informationContent;
            ContactId = contactId;
        }
        public InformationType InformationType { get; set; }
        public string InformationContent { get; set; }
        public string ContactId { get; set; }
    }
}
