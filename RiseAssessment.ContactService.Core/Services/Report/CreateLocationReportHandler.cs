using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiseAssessment.ContactService.Domain.Constants;
using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Dtos;
using RiseAssessment.ContactService.Domain.Models.Enums;
using RiseAssessment.ContactService.Domain.Models.Results;
using RiseAssessment.ContactService.Domain.Models.Results.Report;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;

namespace RiseAssessment.ContactService.Core.Services.Report
{
    public class CreateLocationReportHandler : IRequestHandler<CreateLocationReportCommand, BaseResponseResult<LocationReportResult>>
    {
        private readonly ILogger<CreateLocationReportHandler> _logger;
        private IUnitOfWork _unitOfWork;
        public CreateLocationReportHandler(IUnitOfWork unitOfWork, ILogger<CreateLocationReportHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<BaseResponseResult<LocationReportResult>> Handle(CreateLocationReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<LocationReportResult>();
            try
            {
                int idCount = 0;
                var result = new LocationReportResult();
                result.ReportName = request.ReportName;
                result.CreatedDate = DateTime.UtcNow;

                var dataList = new List<ReportItemDto>();

                _unitOfWork.ContactInformationRepository.Table.Where(x => x.InformationType == InformationType.Location && (string.IsNullOrEmpty(request.Location) || x.InformationContent == request.Location.ToUpper())).Select(x => x.InformationContent).Distinct().ToList().ForEach(location =>
                {
                    var contacts = _unitOfWork.ContactRepository.Table.Where(x => x.ContactInfo.Any(a => a.InformationType == InformationType.Location && a.InformationContent == location));

                    dataList.Add(new ReportItemDto()
                    {
                        Id = ++idCount,
                        Location = location,
                        ContactCount = contacts.Count(),
                        PhoneCount= contacts.SelectMany(nq => nq.ContactInfo).Where(nq => nq.InformationType == InformationType.PhoneNumber).Count()
                    });

                });
                result.ReportItems = dataList;

                response.Result = result;

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
