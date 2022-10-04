using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Commands.ContactInformation;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Core.Services.ContactInformation
{
    public class CreateContactInformationHandler : IRequestHandler<CreateContactInformationCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateContactInformationHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public CreateContactInformationHandler(IUnitOfWork unitOfWork, ILogger<CreateContactInformationHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseResponseResult> Handle(CreateContactInformationCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var getContact = await _unitOfWork.ContactRepository.Table.Include(x => x.ContactInfo).FirstOrDefaultAsync(x => x.Id == Guid.Parse(command.ContactId));
                if (getContact == null)
                {
                    response.Errors.Add("Contact bulunamadı.");
                    return response;

                }
                if (getContact.ContactInfo.FirstOrDefault(x => x.ContactId == Guid.Parse(command.ContactId) && x.InformationContent == command.InformationContent && x.InformationType == command.InformationType) != null)
                {
                    response.Errors.Add("Böyle bir kayıt bulunmaktadır.");
                    return response;

                }
                _unitOfWork.ContactInformationRepository.Add(new Domain.Models.Entities.ContactInformation(command.InformationType, command.InformationContent.ToUpper(), Guid.Parse(command.ContactId)));
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.CompleteAsync(false);
                _logger.LogError(ex, ex.Message);
                response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);
            }

            return response;

        }
    }
}
