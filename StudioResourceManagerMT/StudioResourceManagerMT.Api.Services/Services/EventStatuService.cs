using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class EventStatuService : AbstractEventStatuService, IEventStatuService
	{
		public EventStatuService(
			ILogger<IEventStatuRepository> logger,
			IMediator mediator,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IDALEventStatuMapper dalEventStatuMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
			       eventStatuRepository,
			       eventStatuModelValidator,
			       dalEventStatuMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8b06911971b79378aeec46f298f1d9a0</Hash>
</Codenesium>*/