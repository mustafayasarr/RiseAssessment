using RiseAssessment.ContactService.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Domain.Models.Results.Contact
{
    public class GetContactResult
    {
        public GetContactResult(string id, string name, string lastName, string company, DateTime createdDate, List<ContactInformationDto> contactInformations = null)
        {
            Id = Guid.Parse(id);
            Name = name;
            LastName = lastName;
            Company = company;
            CreatedDate = createdDate;
            ContactInformations = contactInformations;
        }
        public GetContactResult()
        {
            ContactInformations = new List<ContactInformationDto>();
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ContactInformationDto> ContactInformations { get; set; }
    }
}
