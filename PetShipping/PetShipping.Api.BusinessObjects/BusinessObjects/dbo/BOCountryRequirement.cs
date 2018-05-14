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
			IApiCountryRequirementModelValidator countryRequirementModelValidator)
			: base(logger, countryRequirementRepository, countryRequirementModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>816ed1f1d5f3490beb612547f6371095</Hash>
</Codenesium>*/