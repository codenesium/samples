using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCountryRegion: AbstractBOCountryRegion, IBOCountryRegion
	{
		public BOCountryRegion(
			ILogger<CountryRegionRepository> logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper countryRegionMapper)
			: base(logger, countryRegionRepository, countryRegionModelValidator, countryRegionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>50f6fa35a5499059cff3c3e6a0ecb905</Hash>
</Codenesium>*/