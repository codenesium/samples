using MediatR;
using Microsoft.Extensions.Logging;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			IMediator mediator,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper)
			: base(logger,
			       mediator,
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
    <Hash>5b84500434d4da874dfca76c98818e96</Hash>
</Codenesium>*/