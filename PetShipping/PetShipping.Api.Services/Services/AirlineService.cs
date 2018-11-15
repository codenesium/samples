using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class AirlineService : AbstractAirlineService, IAirlineService
	{
		public AirlineService(
			ILogger<IAirlineRepository> logger,
			IAirlineRepository airlineRepository,
			IApiAirlineServerRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolAirlineMapper,
			IDALAirlineMapper dalAirlineMapper)
			: base(logger,
			       airlineRepository,
			       airlineModelValidator,
			       bolAirlineMapper,
			       dalAirlineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0a43500dcecb3f05b9e258ef9dc2084e</Hash>
</Codenesium>*/