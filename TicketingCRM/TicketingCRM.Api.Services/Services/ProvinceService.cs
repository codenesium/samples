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
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
			       mediator,
			       provinceRepository,
			       provinceModelValidator,
			       bolProvinceMapper,
			       dalProvinceMapper,
			       bolCityMapper,
			       dalCityMapper,
			       bolVenueMapper,
			       dalVenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c59b5c2c7267e527e82dd8d1678d72f6</Hash>
</Codenesium>*/