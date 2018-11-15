using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class EventStatuService : AbstractEventStatuService, IEventStatuService
	{
		public EventStatuService(
			ILogger<IEventStatuRepository> logger,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IBOLEventStatuMapper bolEventStatuMapper,
			IDALEventStatuMapper dalEventStatuMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
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
    <Hash>63521ad6873906d82adfd550bc32a77c</Hash>
</Codenesium>*/