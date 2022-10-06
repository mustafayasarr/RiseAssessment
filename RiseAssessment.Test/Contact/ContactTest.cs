using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RiseAssessment.ContactService.ContactAPI.Controllers;
using RiseAssessment.ContactService.Core.Services.Contact;
using RiseAssessment.ContactService.Domain.Models.Commands.Contact;
using RiseAssessment.ContactService.Domain.Models.Entities;
using RiseAssessment.ContactService.Domain.Models.Queries.Contact;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Contact;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.Test.Contact
{
    public class ContactTest
    {
        private readonly Mock<ILogger<ContactController>> _logger;
        private readonly ContactController _controller;
        private readonly Mock<IMediator> mediator;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly List<ContactService.Domain.Models.Entities.Contact> _contact;

        public ContactTest()
        {
            _logger = new Mock<ILogger<ContactController>>();
            mediator = new Mock<IMediator>();
            unitOfWork = new Mock<IUnitOfWork>();
            _contact = SampleData.contactData;
            _controller = new ContactController(_logger.Object, mediator.Object);
        }

        [Fact]
        public async Task GetList_OkResult()
        {
            var a = new BaseResponseResult<List<GetAllContactResult>>();
            mediator.Setup(i => i.Send(It.IsAny<GetAllContactQuery>(), It.IsAny<System.Threading.CancellationToken>()))
    .ReturnsAsync(new BaseResponseResult<List<GetAllContactResult>>());
            unitOfWork.Setup(nq => nq.ContactRepository.Where(null)).Returns(_contact.AsQueryable());

            GetAllContactHandler handler = new GetAllContactHandler(unitOfWork.Object,null);
           
            var caughtException = await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAllContactQuery(), new System.Threading.CancellationToken()));


            var result = await _controller.GetListContact();
            var actionResult = Assert.IsAssignableFrom<ActionResult<BaseResponseResult<List<GetAllContactResult>>>>(result);
            var okResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult.Result);
            var returnContacts = Assert.IsAssignableFrom<BaseResponseResult<List<GetAllContactResult>>>(okResult.Value);

            Assert.True(returnContacts.Result.Count > 0);
        }

    }
}
