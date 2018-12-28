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
    <Hash>3a06e4080159665438d81c88d2824e96</Hash>
</Codenesium>*/