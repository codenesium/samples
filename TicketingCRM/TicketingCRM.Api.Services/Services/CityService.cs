using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CityService : AbstractCityService, ICityService
	{
		public CityService(
			ILogger<ICityRepository> logger,
			ICityRepository cityRepository,
			IApiCityServerRequestModelValidator cityModelValidator,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       cityRepository,
			       cityModelValidator,
			       bolCityMapper,
			       dalCityMapper,
			       bolEventMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9a39d8e2fc38c242ffa11c30624cc89e</Hash>
</Codenesium>*/