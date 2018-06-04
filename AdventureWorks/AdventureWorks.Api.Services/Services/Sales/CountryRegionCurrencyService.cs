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
	public class CountryRegionCurrencyService: AbstractCountryRegionCurrencyService, ICountryRegionCurrencyService
	{
		public CountryRegionCurrencyService(
			ILogger<CountryRegionCurrencyRepository> logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
			IBOLCountryRegionCurrencyMapper BOLcountryRegionCurrencyMapper,
			IDALCountryRegionCurrencyMapper DALcountryRegionCurrencyMapper)
			: base(logger, countryRegionCurrencyRepository,
			       countryRegionCurrencyModelValidator,
			       BOLcountryRegionCurrencyMapper,
			       DALcountryRegionCurrencyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0277e15d7ad514071431f31efcba10c1</Hash>
</Codenesium>*/