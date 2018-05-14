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
	public class BOCountryRegionCurrency: AbstractBOCountryRegionCurrency, IBOCountryRegionCurrency
	{
		public BOCountryRegionCurrency(
			ILogger<CountryRegionCurrencyRepository> logger,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			IApiCountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator)
			: base(logger, countryRegionCurrencyRepository, countryRegionCurrencyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d660d9b79cf36f11f847d43ea7860fdb</Hash>
</Codenesium>*/