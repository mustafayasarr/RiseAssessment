﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiseAssessment.ReportService.Domain.Constants;
using RiseAssessment.ReportService.Domain.Models.Queries;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Domain.Models.Results.Report;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;

namespace RiseAssessment.ReportService.Core.Services.Report
{
    public class GetListReportHandler : IRequestHandler<GetListReportQuery, BaseResponseResult<List<GetReportResult>>>
    {
        private readonly ILogger<GetListReportHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpAccessor;

        public GetListReportHandler(ILogger<GetListReportHandler> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseResponseResult<List<GetReportResult>>> Handle(GetListReportQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult<List<GetReportResult>>();

            try
            {
                response.Result = await _unitOfWork.ReportItemRepository.Table.Select(x => new GetReportResult { Id = x.Id, CreatedDate = x.CreatedAtUTC, Path = string.IsNullOrEmpty(x.Path) ? "" : 
                    $"{_httpAccessor.HttpContext.Request.Scheme}://{_httpAccessor.HttpContext.Request.Host.Value}/Reports/{x.Path}", Status = x.Status }).ToListAsync();

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
