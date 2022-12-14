using RiseAssessment.ContactService.Domain.Models.Entities;
using RiseAssessment.ContactService.Infrastructure.Context;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Infrastructure.Repositories.Concrete
{
    public class ContactInformationRepository : Repository<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }
    }
}
