using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>57b2e6d34247e2803c3974badfab0cc1</Hash>
</Codenesium>*/