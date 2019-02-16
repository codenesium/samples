using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>fccf4a7473eada6df419ee1ebd37599a</Hash>
</Codenesium>*/