using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class SpaceSpaceFeatureService : AbstractSpaceSpaceFeatureService, ISpaceSpaceFeatureService
	{
		public SpaceSpaceFeatureService(
			ILogger<ISpaceSpaceFeatureRepository> logger,
			IMediator mediator,
			ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository,
			IApiSpaceSpaceFeatureServerRequestModelValidator spaceSpaceFeatureModelValidator,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base(logger,
			       mediator,
			       spaceSpaceFeatureRepository,
			       spaceSpaceFeatureModelValidator,
			       dalSpaceSpaceFeatureMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5eb8a1818ced95d19d0091ce86691640</Hash>
</Codenesium>*/