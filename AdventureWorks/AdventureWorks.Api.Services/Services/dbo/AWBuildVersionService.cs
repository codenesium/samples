using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class AWBuildVersionService : AbstractAWBuildVersionService, IAWBuildVersionService
	{
		public AWBuildVersionService(
			ILogger<IAWBuildVersionRepository> logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionServerRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolAWBuildVersionMapper,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base(logger,
			       aWBuildVersionRepository,
			       aWBuildVersionModelValidator,
			       bolAWBuildVersionMapper,
			       dalAWBuildVersionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d4c5b50132fba2098e7f939d37feb3b1</Hash>
</Codenesium>*/