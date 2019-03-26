using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
	{
		public SpaceFeatureService(
			ILogger<ISpaceFeatureRepository> logger,
			IMediator mediator,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureServerRequestModelValidator spaceFeatureModelValidator,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       dalSpaceFeatureMapper,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d31b3248131d6560f743cc0d053f890d</Hash>
</Codenesium>*/