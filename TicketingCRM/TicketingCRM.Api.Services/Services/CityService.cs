using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CityService : AbstractCityService, ICityService
	{
		public CityService(
			ILogger<ICityRepository> logger,
			IMediator mediator,
			ICityRepository cityRepository,
			IApiCityServerRequestModelValidator cityModelValidator,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
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
    <Hash>fc894b4c959c63c62dcfc36c67429994</Hash>
</Codenesium>*/