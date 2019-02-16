using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			IMediator mediator,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IDALCountryMapper dalCountryMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base(logger,
			       mediator,
			       countryRepository,
			       countryModelValidator,
			       dalCountryMapper,
			       dalCountryRequirementMapper,
			       dalDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4cfe605acfec46b3b3f97695cf0a54cf</Hash>
</Codenesium>*/