using MediatR;
using Microsoft.Extensions.Logging;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Commands.Contact;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Core.Services.Contact
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateContactHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public CreateContactHandler(IUnitOfWork unitOfWork, ILogger<CreateContactHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseResult> Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var contactEntity = new Domain.Models.Entities.Contact(command.Name.ToUpper(), command.LastName.ToUpper(), command.Company.ToUpper());
                _unitOfWork.ContactRepository.Add(contactEntity);
                if (command.ContactInformation != null && command.ContactInformation.Count > 0)
                {

                    var entityInfoList = command.ContactInformation.Select(x => new Domain.Models.Entities.ContactInformation(x.InformationType, x.InformationContent.ToUpper(), contactEntity.Id));

                    _unitOfWork.ContactInformationRepository.AddRange(entityInfoList);

                }
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
