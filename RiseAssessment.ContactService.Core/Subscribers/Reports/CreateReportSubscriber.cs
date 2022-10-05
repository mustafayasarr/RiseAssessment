using DotNetCore.CAP;
using MediatR;
using Newtonsoft.Json;
using RiseAssessment.ContactService.Core.Gateways.ContactService;
using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Dtos;
using RiseAssessment.ContactService.Domain.Models.Enums;
using RiseAssessment.ContactService.Domain.Models.Events;
using RiseAssessment.ContactService.Domain.Models.Results;

namespace RiseAssessment.ContactService.Core.Subscribers.Reports
{
    public class CreateReportSubscriber : ICapSubscribe
    {
        private readonly IMediator _mediator;
        private readonly IReportGateway _reportGateway;
        public CreateReportSubscriber(IMediator mediator, IReportGateway reportGateway)
        {
            _mediator = mediator;
            _reportGateway = reportGateway;
        }
        [CapSubscribe(Domain.Constants.ReportSubscriberConstant.CreateReportQueue)]
        public async Task ReportCreateAsync(CreateReportEvent @event)
        {
            UpdateLocationReportDto request = new UpdateLocationReportDto();
            var response = await _mediator.Send(new CreateLocationReportCommand(@event.Id, @event.ReportName, @event.Location));
            if (response.HasError)
            {
                request.Status = Status.Hata;
                request.Message = response.Errors.FirstOrDefault();
            }
            else
            {
                request.Status = Status.Tamamlandi;
                request.CreatedDate = response.Result.CreatedDate;
                request.ReportItems = response.Result.ReportItems;
                request.ReportName = response.Result.ReportName;

            }
            request.Id = @event.Id;
            request.JsonRequest = JsonConvert.SerializeObject(@event);


            await _reportGateway.UpdateReport(request);
        }
    }
}
