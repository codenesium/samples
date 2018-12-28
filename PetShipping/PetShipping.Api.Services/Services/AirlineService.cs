using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class AirlineService : AbstractAirlineService, IAirlineService
	{
		public AirlineService(
			ILogger<IAirlineRepository> logger,
			IMediator mediator,
			IAirlineRepository airlineRepository,
			IApiAirlineServerRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolAirlineMapper,
			IDALAirlineMapper dalAirlineMapper)
			: base(logger,
			       mediator,
			       airlineRepository,
			       airlineModelValidator,
			       bolAirlineMapper,
			       dalAirlineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>56e66720e9602747e0a04bea45187917</Hash>
</Codenesium>*/