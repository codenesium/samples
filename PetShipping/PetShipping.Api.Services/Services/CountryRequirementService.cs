using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>fbaef0ebb2b015f70f175afccfe6e0b5</Hash>
</Codenesium>*/