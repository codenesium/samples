using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>b1bd17a9a18beda1bdceae4999406811</Hash>
</Codenesium>*/