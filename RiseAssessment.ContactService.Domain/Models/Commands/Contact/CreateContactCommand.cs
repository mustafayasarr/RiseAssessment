using MediatR;
using RiseAssessment.ContactService.Domain.Models.Dtos;
using RiseAssessment.ContactService.Domain.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Commands.Contact
{
    public class CreateContactCommand : IRequest<BaseResponseResult>
    {
        public CreateContactCommand()
        {
            ContactInformation = new List<ContactInformationDto>();
        }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public List<ContactInformationDto> ContactInformation { get; set; }
    }

}
