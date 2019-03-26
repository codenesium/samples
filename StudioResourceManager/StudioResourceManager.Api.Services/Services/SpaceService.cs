using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class SpaceService : AbstractSpaceService, ISpaceService
	{
		public SpaceService(
			ILogger<ISpaceRepository> logger,
			IMediator mediator,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IDALSpaceMapper dalSpaceMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceRepository,
			       spaceModelValidator,
			       dalSpaceMapper,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc2cc1ef301b25d0fc5d046fc039fd34</Hash>
</Codenesium>*/