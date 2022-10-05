using ClosedXML.Excel;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using RiseAssessment.ReportService.Domain.Constants;
using RiseAssessment.ReportService.Domain.Models.Commands;
using RiseAssessment.ReportService.Domain.Models.Results;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Core.Services.Report
{
    public class UpdateLocationReportHandler : IRequestHandler<UpdateLocationReportCommand, BaseResponseResult>
    {
        private readonly ILogger<UpdateLocationReportHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UpdateLocationReportHandler(ILogger<UpdateLocationReportHandler> logger, IUnitOfWork unitOfWork, IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseResponseResult> Handle(UpdateLocationReportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponseResult();
            try
            {
                var getEntity = await _unitOfWork.ReportItemRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (getEntity != null)
                {
                    getEntity.Path = Excel(request);
                    getEntity.Status = Domain.Models.Enums.Status.Tamamlandi;
                    await _unitOfWork.ReportItemRepository.UpdateAsync(getEntity);
                    await _unitOfWork.CompleteAsync();
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.CompleteAsync(false);
                _logger.LogError(ex, ex.Message);
                response.Errors.Add(ResponseMessageConstants.AnErrorOccurred);

            }
            return response;
        }
        private string Excel(UpdateLocationReportCommand command)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Location Report");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Location";
                worksheet.Cell(currentRow, 3).Value = "Contact Count";
                worksheet.Cell(currentRow, 4).Value = "Phone Count";

                worksheet.Row(currentRow).CellsUsed().Style.Font.SetBold();
                worksheet.Row(currentRow).CellsUsed().Style.Font.SetFontSize(12);
                worksheet.Row(currentRow).CellsUsed().Style.Fill.SetBackgroundColor(XLColor.LightGray);

                foreach (var item in command.ReportItems)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Id;
                    worksheet.Cell(currentRow, 2).Value = item.Location;
                    worksheet.Cell(currentRow, 3).Value = item.ContactCount;
                    worksheet.Cell(currentRow, 4).Value = item.PhoneCount;
                }
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    var fileName = $"LocationReport" + Guid.NewGuid().ToString() + ".xlsx";
                    string tempFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Reports", fileName);
                    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.WriteTo(fs);
                    }
                    return fileName;
                }

            }

        }
    }
}
