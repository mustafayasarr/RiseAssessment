using DotNetCore.CAP;
using MediatR;
using RiseAssessment.ContactService.Core.Gateways.ContactService;
using RiseAssessment.ContactService.Domain.Models.Commands.Report;
using RiseAssessment.ContactService.Domain.Models.Events;

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
            var response = await _mediator.Send(new CreateLocationReportCommand(@event.Id,@event.ReportName, @event.Location));
            await _reportGateway.UpdateReport(response.Result);
        }
    }
}
