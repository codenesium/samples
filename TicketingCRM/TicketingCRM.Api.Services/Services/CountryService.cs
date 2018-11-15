using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper)
			: base(logger,
			       countryRepository,
			       countryModelValidator,
			       bolCountryMapper,
			       dalCountryMapper,
			       bolProvinceMapper,
			       dalProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6dfc9bd285c89d32900e38302ae0cb8e</Hash>
</Codenesium>*/