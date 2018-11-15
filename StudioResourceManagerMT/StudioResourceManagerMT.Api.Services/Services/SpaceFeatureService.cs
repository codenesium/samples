using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<ISpaceFeatureRepository> logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureServerRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper)
			: base(logger,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5cdbfd823cf78b901d65e9db148c25aa</Hash>
</Codenesium>*/