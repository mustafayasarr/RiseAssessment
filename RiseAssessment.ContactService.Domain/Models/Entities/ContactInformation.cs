using RiseAssessment.ContactService.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Entities
{
    public class ContactInformation : EntityBase<int>
    {
        public ContactInformation(InformationType informationType, string informationContent, Guid contactId)
        {
            InformationType = informationType;
            InformationContent = informationContent;
            ContactId = contactId;
        }
        public ContactInformation()
        {

        }
        public InformationType InformationType { get; set; }
        public string? InformationContent { get; set; }
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
