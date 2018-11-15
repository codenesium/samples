using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CountryRequirementService : AbstractCountryRequirementService, ICountryRequirementService
	{
		public CountryRequirementService(
			ILogger<ICountryRequirementRepository> logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementServerRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base(logger,
			       countryRequirementRepository,
			       countryRequirementModelValidator,
			       bolCountryRequirementMapper,
			       dalCountryRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8aa7506a64c4c786409cb196b9d856d4</Hash>
</Codenesium>*/