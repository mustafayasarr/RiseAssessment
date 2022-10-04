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
    public class RemoveContactHandler : IRequestHandler<RemoveContactCommand, BaseResponseResult>
    {
        private readonly ILogger<RemoveContactHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public RemoveContactHandler(IUnitOfWork unitOfWork, ILogger<RemoveContactHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseResult> Handle(RemoveContactCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var getContact = await _unitOfWork.ContactRepository.FirstOrDefaultAsync(x => x.Id == Guid.Parse(command.ContactId));
                if (getContact == null)
                {
                    response.Errors.Add("Contact bulunamadı.");
                    return response;

                }
                _unitOfWork.ContactRepository.Delete(getContact);

                var getContactInfos = await _unitOfWork.ContactInformationRepository.ToListAsync(x => x.ContactId == Guid.Parse(command.ContactId));
                if (getContactInfos != null && getContactInfos.Count > 0)
                {
                    _unitOfWork.ContactInformationRepository.DeleteRange(getContactInfos);
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
