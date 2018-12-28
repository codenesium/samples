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
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper)
			: base(logger,
			       mediator,
			       airTransportRepository,
			       airTransportModelValidator,
			       bolAirTransportMapper,
			       dalAirTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e009e77432ee217f2dcbd686d9e85a6</Hash>
</Codenesium>*/