using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>12468f348106ecd77acd9f638b6536d7</Hash>
</Codenesium>*/