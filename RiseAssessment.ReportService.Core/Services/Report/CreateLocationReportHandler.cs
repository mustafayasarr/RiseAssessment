using DotNetCore.CAP;
using MediatR;
using Microsoft.Extensions.Logging;
using RiseAssessment.ReportService.Domain.Constants;
using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Enums;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;

namespace RiseAssessment.ReportService.Core.Services.Report
{
    public class CreateLocationReportHandler : IRequestHandler<CreateLocationReportCommand, BaseResponseResult>
    {
        private readonly ILogger<CreateLocationReportHandler> _logger;
        private readonly ICapPublisher _capPublisher;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLocationReportHandler(ICapPublisher capPublisher, ILogger<CreateLocationReportHandler> logger, IUnitOfWork unitOfWork)
        {

            _logger = logger;
            _capPublisher = capPublisher;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseResponseResult> Handle(CreateLocationReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var entity = new Domain.Models.Entities.ReportItem(Status.Bekliyor);
                await _unitOfWork.ReportItemRepository.CreateAsync(entity);
                await _unitOfWork.CompleteAsync();
                request.Id = entity.Id;
                await _capPublisher.PublishAsync(ContactSubscriberConstant.CreateReportQueue, request);
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
