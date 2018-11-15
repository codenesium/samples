using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class ProvinceService : AbstractProvinceService, IProvinceService
	{
		public ProvinceService(
			ILogger<IProvinceRepository> logger,
			IProvinceRepository provinceRepository,
			IApiProvinceServerRequestModelValidator provinceModelValidator,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base(logger,
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
    <Hash>e943920ee12fa140255bdcb03cbe4be7</Hash>
</Codenesium>*/