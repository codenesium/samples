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
			IDALCountryMapper dalCountryMapper,
			IDALProvinceMapper dalProvinceMapper)
			: base(logger,
			       mediator,
			       countryRepository,
			       countryModelValidator,
			       dalCountryMapper,
			       dalProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1a9ce92412b00513d2030c364a42f158</Hash>
</Codenesium>*/