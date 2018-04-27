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
			ICountryRequirementModelValidator countryRequirementModelValidator)
			: base(logger, countryRequirementRepository, countryRequirementModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>82232fbea4586c42806d2f09a289e3f5</Hash>
</Codenesium>*/