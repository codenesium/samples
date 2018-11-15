using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			ICountryRepository countryRepository,
			IApiCountryServerRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolCountryMapper,
			IDALCountryMapper dalCountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper)
			: base(logger,
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
    <Hash>5af8494634115f1049207fb284e48a66</Hash>
</Codenesium>*/