using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class SpaceSpaceFeatureService : AbstractSpaceSpaceFeatureService, ISpaceSpaceFeatureService
	{
		public SpaceSpaceFeatureService(
			ILogger<ISpaceSpaceFeatureRepository> logger,
			IMediator mediator,
			ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository,
			IApiSpaceSpaceFeatureServerRequestModelValidator spaceSpaceFeatureModelValidator,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceSpaceFeatureRepository,
			       spaceSpaceFeatureModelValidator,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>aa28ffb364a240679116b3c3d8fba296</Hash>
</Codenesium>*/