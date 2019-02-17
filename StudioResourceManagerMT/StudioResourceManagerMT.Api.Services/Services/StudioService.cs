using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class StudioService : AbstractStudioService, IStudioService
	{
		public StudioService(
			ILogger<IStudioRepository> logger,
			IMediator mediator,
			IStudioRepository studioRepository,
			IApiStudioServerRequestModelValidator studioModelValidator,
			IDALStudioMapper dalStudioMapper)
			: base(logger,
			       mediator,
			       studioRepository,
			       studioModelValidator,
			       dalStudioMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a16c8351e3a8b4d8a0f2c12bc5a5a33b</Hash>
</Codenesium>*/