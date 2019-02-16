using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>d55f0d1acd72159410e3b85b7bf8840b</Hash>
</Codenesium>*/