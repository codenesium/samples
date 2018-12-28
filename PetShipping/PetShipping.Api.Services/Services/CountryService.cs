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
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base(logger,
			       mediator,
			       countryRepository,
			       countryModelValidator,
			       bolCountryMapper,
			       dalCountryMapper,
			       bolCountryRequirementMapper,
			       dalCountryRequirementMapper,
			       bolDestinationMapper,
			       dalDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ced9d641ea4fd86bc4c59b8cc9d533d7</Hash>
</Codenesium>*/