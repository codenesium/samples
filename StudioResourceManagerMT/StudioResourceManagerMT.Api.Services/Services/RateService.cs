using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class RateService : AbstractRateService, IRateService
	{
		public RateService(
			ILogger<IRateRepository> logger,
			IMediator mediator,
			IRateRepository rateRepository,
			IApiRateServerRequestModelValidator rateModelValidator,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       mediator,
			       rateRepository,
			       rateModelValidator,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e4d4ee82d7d3aab9f86c65ff53b9273a</Hash>
</Codenesium>*/