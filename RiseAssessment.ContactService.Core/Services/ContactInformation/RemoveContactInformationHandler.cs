using MediatR;
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
    public class RemoveContactInformationHandler : IRequestHandler<RemoveContactInformationCommand, BaseResponseResult>
    {
        private readonly ILogger<RemoveContactInformationHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public RemoveContactInformationHandler(IUnitOfWork unitOfWork, ILogger<RemoveContactInformationHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseResult> Handle(RemoveContactInformationCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var getEntity = await _unitOfWork.ContactInformationRepository.FirstOrDefaultAsync(x => x.Id == command.ContactInformationId && x.ContactId == Guid.Parse(command.ContactId));
                if (getEntity == null)
                {
                    response.Errors.Add("Contact information bulunamadı.");
                    return response;

                }
                _unitOfWork.ContactInformationRepository.Delete(getEntity);
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
