using MediatR;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Queries.Contact
{
    public class GetContactQuery : IRequest<BaseResponseResult<GetContactResult>>
    {
        public GetContactQuery(string contactId)
        {
            ContactId = Guid.Parse(contactId);
        }
        public Guid ContactId { get; set; }
    }
}
