using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>a8f4e5ffce052f92108953d80c709612</Hash>
</Codenesium>*/