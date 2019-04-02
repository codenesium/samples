using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class EventStatusService : AbstractEventStatusService, IEventStatusService
	{
		public EventStatusService(
			ILogger<IEventStatusRepository> logger,
			IMediator mediator,
			IEventStatusRepository eventStatusRepository,
			IApiEventStatusServerRequestModelValidator eventStatusModelValidator,
			IDALEventStatusMapper dalEventStatusMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
			       eventStatusRepository,
			       eventStatusModelValidator,
			       dalEventStatusMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c8afa1c1b1b2d1dc3a17a7b262a1587</Hash>
</Codenesium>*/