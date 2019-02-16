using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>839469f88071b59136235098ffa6032e</Hash>
</Codenesium>*/