using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class CountryRequirementService: AbstractCountryRequirementService, ICountryRequirementService
	{
		public CountryRequirementService(
			ILogger<CountryRequirementRepository> logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper BOLcountryRequirementMapper,
			IDALCountryRequirementMapper DALcountryRequirementMapper)
			: base(logger, countryRequirementRepository,
			       countryRequirementModelValidator,
			       BOLcountryRequirementMapper,
			       DALcountryRequirementMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a74f3e9fbd277042b0e2d484de8a074c</Hash>
</Codenesium>*/