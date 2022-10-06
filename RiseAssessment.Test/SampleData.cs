
using RiseAssessment.ReportService.Domain.Models.Entities;

namespace RiseAssessment.Test
{
    public class SampleData
    {
        public static List<ContactService.Domain.Models.Entities.Contact> contactData = new List<ContactService.Domain.Models.Entities.Contact>()
        {
            new ContactService.Domain.Models.Entities.Contact()
            {
                Id = Guid.Parse("965a7a27-52d1-4d96-9520-54d18e37e3d7"),
                Name = "Mustafa",
                LastName = "Yaşar",
                Company = "YAŞAR Inc.",
              
            },
            new ContactService.Domain.Models.Entities.Contact()
                {
                    Id = Guid.Parse("d8f7392e-f685-4b4d-b4e7-0b856f38db39"),
                    Name = "Ahmet",
                    LastName = "Çakır",
                    Company = "Çakır Inc."
                },
            new ContactService.Domain.Models.Entities.Contact()
                {
                    Id =Guid.Parse("3c52642a-949e-4309-ae60-0e56c78dceb4"),
                    Name = "Seda",
                    LastName = "Söylemez",
                    Company = "Söylemez Inc."
                },
            new ContactService.Domain.Models.Entities.Contact()
                {
                    Id = Guid.Parse("d68a90f2-b6a7-4f85-9b55-77aa484a79d5"),
                    Name = "Ayşe",
                    LastName = "Bahadır",
                    Company = "Bahadır Inc."
                }
        };

        public static List<ContactService.Domain.Models.Entities.ContactInformation> contactInformationData = new List<ContactService.Domain.Models.Entities.ContactInformation>()
        {
            new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 1,
                    ContactId =Guid.Parse("965a7a27-52d1-4d96-9520-54d18e37e3d7") ,
                    InformationType = ContactService.Domain.Models.Enums.InformationType.EmailAddress,
                    InformationContent = "mustafa@yasar.com"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 2,
                    ContactId = Guid.Parse("965a7a27-52d1-4d96-9520-54d18e37e3d7") ,
                    InformationType = ContactService.Domain.Models.Enums.InformationType.PhoneNumber,
                    InformationContent = "+905333333333"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 3,
                    ContactId = Guid.Parse("965a7a27-52d1-4d96-9520-54d18e37e3d7") ,
                    InformationType = ContactService.Domain.Models.Enums.InformationType.Location,
                    InformationContent = "İSTANBUL"
                },


                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 4,
                    ContactId = Guid.Parse("d8f7392e-f685-4b4d-b4e7-0b856f38db39"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.EmailAddress,
                    InformationContent = "ahmet@cakir.com"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 5,
                    ContactId = Guid.Parse("d8f7392e-f685-4b4d-b4e7-0b856f38db39"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.PhoneNumber,
                    InformationContent = "+90533333333"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 6,
                    ContactId = Guid.Parse("d8f7392e-f685-4b4d-b4e7-0b856f38db39"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.Location,
                    InformationContent = "BURSA"
                },


                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 7,
                    ContactId = Guid.Parse("3c52642a-949e-4309-ae60-0e56c78dceb4"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.EmailAddress,
                    InformationContent = "sedat@soylemez.com"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 8,
                    ContactId = Guid.Parse("3c52642a-949e-4309-ae60-0e56c78dceb4"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.PhoneNumber,
                    InformationContent = "+905333333336"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 9,
                    ContactId = Guid.Parse("3c52642a-949e-4309-ae60-0e56c78dceb4"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.Location,
                    InformationContent = "İZMİR"
                },


                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 10,
                    ContactId = Guid.Parse("d68a90f2-b6a7-4f85-9b55-77aa484a79d5"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.EmailAddress,
                    InformationContent = "ayse@bahadir.com"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 11,
                    ContactId = Guid.Parse("d68a90f2-b6a7-4f85-9b55-77aa484a79d5"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.PhoneNumber,
                    InformationContent = "+902111111111"
                },
                new ContactService.Domain.Models.Entities.ContactInformation()
                {
                    Id = 12,
                    ContactId = Guid.Parse("d68a90f2-b6a7-4f85-9b55-77aa484a79d5"),
                    InformationType = ContactService.Domain.Models.Enums.InformationType.Location,
                    InformationContent = "İSTANBUL"
                }
        };

        public static List<ReportItem> reportData = new List<ReportItem>()
        {
            new ReportItem()
            {
                Id = 1,
                CreatedAtUTC = DateTime.Now.AddMinutes(-3),
                ReportCreateDate = DateTime.Now,
                Path = "/Reports/8db7ef4e-1.xlsx",
                Status = ReportService.Domain.Models.Enums.Status.Tamamlandi,
                ReportName="Test1"
            },
            new ReportItem()
            {
                Id = 2,
                CreatedAtUTC = DateTime.Now.AddMinutes(-3),
                ReportCreateDate = DateTime.Now,
                Path = "/Reports/8db7ef4e-1.xlsx",
                Status = ReportService.Domain.Models.Enums.Status.Tamamlandi,
                ReportName="Test2"

            },
            new ReportItem()
            {
                Id = 3,
                CreatedAtUTC = DateTime.Now.AddMinutes(-3),
                Status = ReportService.Domain.Models.Enums.Status.Bekliyor,
                ReportName="Test3"
            }
        };
    }
}