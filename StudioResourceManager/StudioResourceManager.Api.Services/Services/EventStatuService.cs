using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>61a5b99f847137ff59d5b1625f073c90</Hash>
</Codenesium>*/