using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class ProvinceService : AbstractProvinceService, IProvinceService
	{
		public ProvinceService(
			ILogger<IProvinceRepository> logger,
			IMediator mediator,
			IProvinceRepository provinceRepository,
			IApiProvinceServerRequestModelValidator provinceModelValidator,
			IDALProvinceMapper dalProvinceMapper,
			IDALCityMapper dalCityMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       mediator,
			       provinceRepository,
			       provinceModelValidator,
			       dalProvinceMapper,
			       dalCityMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e7199fecb7ea84456e9f09e7a1b047de</Hash>
</Codenesium>*/