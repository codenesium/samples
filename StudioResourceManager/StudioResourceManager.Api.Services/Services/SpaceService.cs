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
    <Hash>bf83f5cc23a8b26e6585bacf3b2d42f4</Hash>
</Codenesium>*/