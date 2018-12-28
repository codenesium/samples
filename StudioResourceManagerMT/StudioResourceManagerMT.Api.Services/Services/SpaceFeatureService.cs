using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<ISpaceFeatureRepository> logger,
			IMediator mediator,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureServerRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6259e1241aa98928d0c1fde76542f83a</Hash>
</Codenesium>*/