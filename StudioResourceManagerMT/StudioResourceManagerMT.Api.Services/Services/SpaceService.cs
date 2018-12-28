using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>ffe6a559babd2067b1d5a4332e56cfd0</Hash>
</Codenesium>*/