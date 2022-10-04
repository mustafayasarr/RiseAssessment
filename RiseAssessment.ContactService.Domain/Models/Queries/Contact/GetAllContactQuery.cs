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
    public class GetAllContactQuery : IRequest<BaseResponseResult<List<GetAllContactResult>>>
    {
    }
}
