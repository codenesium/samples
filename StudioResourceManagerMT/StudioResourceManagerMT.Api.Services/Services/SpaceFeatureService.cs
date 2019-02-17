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
			IDALSpaceFeatureMapper dalSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       dalSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2e6325e4c65c8b85f178f77c583363aa</Hash>
</Codenesium>*/