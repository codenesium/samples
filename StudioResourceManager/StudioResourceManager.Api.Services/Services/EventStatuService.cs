using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class EventStatuService : AbstractEventStatuService, IEventStatuService
	{
		public EventStatuService(
			ILogger<IEventStatuRepository> logger,
			IMediator mediator,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IBOLEventStatuMapper bolEventStatuMapper,
			IDALEventStatuMapper dalEventStatuMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
			       eventStatuRepository,
			       eventStatuModelValidator,
			       bolEventStatuMapper,
			       dalEventStatuMapper,
			       bolEventMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e3b46a1c6c81abcdef20048f5d85a6cd</Hash>
</Codenesium>*/