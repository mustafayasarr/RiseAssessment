using MediatR;
using RiseAssessment.ContactService.Domain.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Commands.Contact
{
    public class RemoveContactCommand : IRequest<BaseResponseResult>
    {
        public string ContactId { get; set; }

    }
}
