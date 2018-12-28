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
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator,
			       bolSpaceFeatureMapper,
			       dalSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8b1d94275cd1b73280fcef9a19e828ac</Hash>
</Codenesium>*/