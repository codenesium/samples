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
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper)
			: base(logger,
			       mediator,
			       spaceRepository,
			       spaceModelValidator,
			       bolSpaceMapper,
			       dalSpaceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4c11a3a5583b2757dcd1b39083202954</Hash>
</Codenesium>*/