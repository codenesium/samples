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
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator)
			: base(logger, countryRegionCurrencyRepository, countryRegionCurrencyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>346efc094a4875e3eb1423ad0db0cc8f</Hash>
</Codenesium>*/