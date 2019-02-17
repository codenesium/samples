using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>156a81247a258ad1e1c26ed8b10c80a9</Hash>
</Codenesium>*/