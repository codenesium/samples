using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class AirTransportService : AbstractAirTransportService, IAirTransportService
	{
		public AirTransportService(
			ILogger<IAirTransportRepository> logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportServerRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper)
			: base(logger,
			       airTransportRepository,
			       airTransportModelValidator,
			       bolAirTransportMapper,
			       dalAirTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e2e0d16d08feb576d45168fb1f382a83</Hash>
</Codenesium>*/