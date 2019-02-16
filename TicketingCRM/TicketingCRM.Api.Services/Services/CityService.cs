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
			IDALCityMapper dalCityMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       mediator,
			       cityRepository,
			       cityModelValidator,
			       dalCityMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>89e333a5da08d287a2517ff1c46399b2</Hash>
</Codenesium>*/