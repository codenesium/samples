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
			IDALSpaceMapper dalSpaceMapper)
			: base(logger,
			       mediator,
			       spaceRepository,
			       spaceModelValidator,
			       dalSpaceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5bc023466d31f1754c2c5d4dca388589</Hash>
</Codenesium>*/