using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>c37bcd0e9d311286522c032790e774ab</Hash>
</Codenesium>*/