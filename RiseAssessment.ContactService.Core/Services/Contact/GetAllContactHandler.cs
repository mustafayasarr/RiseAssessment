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
    public class GetAllContactHandler : IRequestHandler<GetAllContactQuery, BaseResponseResult<List<GetAllContactResult>>>
    {
        private readonly ILogger<GetAllContactHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public GetAllContactHandler(IUnitOfWork unitOfWork, ILogger<GetAllContactHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseResponseResult<List<GetAllContactResult>>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<List<GetAllContactResult>>();
            try
            {
                response.Result = await _unitOfWork.ContactRepository.Table.Include(x => x.ContactInfo)
                    .Select(x => new GetAllContactResult
                    (x.Id.ToString(), x.Name, x.LastName, x.Company, x.CreatedAtUTC,
                    x.ContactInfo.Select(a => new Domain.Models.Dtos.ContactInformationDto
                    { Id = a.Id, CreatedDate = a.CreatedAtUTC, InformationContent = a.InformationContent, InformationType = a.InformationType }
                    )
                    .ToList())).ToListAsync();

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
