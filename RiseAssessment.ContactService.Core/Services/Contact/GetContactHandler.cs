using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Queries.Contact;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Contact;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Core.Services.Contact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, BaseResponseResult<Domain.Models.Results.Contact.GetContactResult>>
    {
        private readonly ILogger<GetContactHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public GetContactHandler(IUnitOfWork unitOfWork, ILogger<GetContactHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseResponseResult<GetContactResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<GetContactResult>();
            try
            {
                response.Result = await (from item in _unitOfWork.ContactRepository.Table.Include(x => x.ContactInfo)
                                         where item.Id == request.ContactId
                                         select new GetContactResult()
                                         {
                                             Id = item.Id,
                                             Name = item.Name,
                                             LastName = item.LastName,
                                             Company = item.Company,
                                             CreatedDate = item.CreatedAtUTC,
                                             ContactInformations = item.ContactInfo.Select(x => new Domain.Models.Dtos.ContactInformationDto(x.Id, x.InformationType, x.InformationContent, x.CreatedAtUTC)).ToList(),

                                         }).FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
            }
            return response;
        }
    }
}
