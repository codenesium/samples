using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       eventRepository,
			       eventModelValidator,
			       bolEventMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e3a8acc6a010f079d9519ac6953f9ae5</Hash>
</Codenesium>*/