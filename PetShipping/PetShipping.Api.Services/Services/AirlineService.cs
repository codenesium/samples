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
			IDALAirlineMapper dalAirlineMapper)
			: base(logger,
			       mediator,
			       airlineRepository,
			       airlineModelValidator,
			       dalAirlineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>90390d94eccb2df5c2089e023ef090d6</Hash>
</Codenesium>*/