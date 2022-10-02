using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Entities
{
    public class Contact : EntityBase<Guid>
    {
        public Contact(string name, string lastName, string company)
        {
            Name = name;
            LastName = lastName;
            Company = company;

        }
        public Contact()
        {
            ContactInfo = new List<ContactInformation>();

        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public ICollection<ContactInformation> ContactInfo { get; set; }

    }
}
