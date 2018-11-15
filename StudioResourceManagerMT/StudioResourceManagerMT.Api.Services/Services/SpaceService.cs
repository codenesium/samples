using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class SpaceService : AbstractSpaceService, ISpaceService
	{
		public SpaceService(
			ILogger<ISpaceRepository> logger,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper)
			: base(logger,
			       spaceRepository,
			       spaceModelValidator,
			       bolSpaceMapper,
			       dalSpaceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7d6124314cebca724515af884b5f9483</Hash>
</Codenesium>*/