using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class CountryRequirementService : AbstractCountryRequirementService, ICountryRequirementService
	{
		public CountryRequirementService(
			ILogger<ICountryRequirementRepository> logger,
			IMediator mediator,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementServerRequestModelValidator countryRequirementModelValidator,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base(logger,
			       mediator,
			       countryRequirementRepository,
			       countryRequirementModelValidator,
			       dalCountryRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1034da24b9e15871f7bbae18bd2b4f61</Hash>
</Codenesium>*/