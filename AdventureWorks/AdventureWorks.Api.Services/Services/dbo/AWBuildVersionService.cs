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
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base(logger,
			       mediator,
			       aWBuildVersionRepository,
			       aWBuildVersionModelValidator,
			       dalAWBuildVersionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>94be197a8c453ccdab412ca7475d9379</Hash>
</Codenesium>*/