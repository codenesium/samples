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
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper)
			: base(logger,
			       mediator,
			       countryRequirementRepository,
			       countryRequirementModelValidator,
			       bolCountryRequirementMapper,
			       dalCountryRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4a9c71a80d1a3870f213572de1f1bcbc</Hash>
</Codenesium>*/