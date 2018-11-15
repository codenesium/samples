using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class StudioService : AbstractStudioService, IStudioService
	{
		public StudioService(
			ILogger<IStudioRepository> logger,
			IStudioRepository studioRepository,
			IApiStudioServerRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper)
			: base(logger,
			       studioRepository,
			       studioModelValidator,
			       bolStudioMapper,
			       dalStudioMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e53d5589a7c02d14b97f377ac0c86a4e</Hash>
</Codenesium>*/