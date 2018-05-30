using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOCountryRequirement: AbstractBOCountryRequirement, IBOCountryRequirement
	{
		public BOCountryRequirement(
			ILogger<CountryRequirementRepository> logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper countryRequirementMapper)
			: base(logger, countryRequirementRepository, countryRequirementModelValidator, countryRequirementMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>580582bcd022670f55a46737a3f9960f</Hash>
</Codenesium>*/