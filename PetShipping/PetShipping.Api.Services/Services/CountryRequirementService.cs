using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class CountryRequirementService : AbstractCountryRequirementService, ICountryRequirementService
	{
		public CountryRequirementService(
			ILogger<ICountryRequirementRepository> logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementRequestModelValidator countryRequirementModelValidator,
			IBOLCountryRequirementMapper bolcountryRequirementMapper,
			IDALCountryRequirementMapper dalcountryRequirementMapper)
			: base(logger,
			       countryRequirementRepository,
			       countryRequirementModelValidator,
			       bolcountryRequirementMapper,
			       dalcountryRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>286b0ec0f89ecd0561148a72edc3e6ad</Hash>
</Codenesium>*/