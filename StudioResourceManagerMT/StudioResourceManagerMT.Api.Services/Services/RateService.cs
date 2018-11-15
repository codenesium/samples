using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class RateService : AbstractRateService, IRateService
	{
		public RateService(
			ILogger<IRateRepository> logger,
			IRateRepository rateRepository,
			IApiRateServerRequestModelValidator rateModelValidator,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       rateRepository,
			       rateModelValidator,
			       bolRateMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3092a9be4176f6e40ab740f98032b173</Hash>
</Codenesium>*/