using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IMediator mediator,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
			       eventRepository,
			       eventModelValidator,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b2832e0fa1f7b8a643e8f07323ad00f</Hash>
</Codenesium>*/