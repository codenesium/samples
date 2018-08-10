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
			IDALCountryRequirementMapper dalcountryRequirementMapper
			)
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
    <Hash>a65aa347f8cfb93b172f6d232c387fc8</Hash>
</Codenesium>*/