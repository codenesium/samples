using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class AirTransportService : AbstractAirTransportService, IAirTransportService
	{
		public AirTransportService(
			ILogger<IAirTransportRepository> logger,
			IMediator mediator,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportServerRequestModelValidator airTransportModelValidator,
			IDALAirTransportMapper dalAirTransportMapper)
			: base(logger,
			       mediator,
			       airTransportRepository,
			       airTransportModelValidator,
			       dalAirTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3bd4785d093acc23976abeb42bab7e40</Hash>
</Codenesium>*/