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
			IDALEventStatuMapper dalEventStatuMapper)
			: base(logger,
			       mediator,
			       eventStatuRepository,
			       eventStatuModelValidator,
			       dalEventStatuMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2faaaf72826e1135198358de9dce3a93</Hash>
</Codenesium>*/