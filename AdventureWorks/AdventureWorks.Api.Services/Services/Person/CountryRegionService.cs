using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CountryRegionService: AbstractCountryRegionService, ICountryRegionService
	{
		public CountryRegionService(
			ILogger<CountryRegionRepository> logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper BOLcountryRegionMapper,
			IDALCountryRegionMapper DALcountryRegionMapper)
			: base(logger, countryRegionRepository,
			       countryRegionModelValidator,
			       BOLcountryRegionMapper,
			       DALcountryRegionMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f61f57db16e917180003eb7e58a800da</Hash>
</Codenesium>*/