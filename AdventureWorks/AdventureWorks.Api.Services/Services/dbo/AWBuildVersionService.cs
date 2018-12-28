using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AWBuildVersionService : AbstractAWBuildVersionService, IAWBuildVersionService
	{
		public AWBuildVersionService(
			ILogger<IAWBuildVersionRepository> logger,
			IMediator mediator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionServerRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolAWBuildVersionMapper,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base(logger,
			       mediator,
			       aWBuildVersionRepository,
			       aWBuildVersionModelValidator,
			       bolAWBuildVersionMapper,
			       dalAWBuildVersionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8b12dab84fe9b6ee6aa5eccc2f1a1107</Hash>
</Codenesium>*/