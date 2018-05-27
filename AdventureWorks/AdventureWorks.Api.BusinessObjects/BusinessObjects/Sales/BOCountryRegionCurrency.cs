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
			IApiCountryRegionCurrencyRequestModelValidator countryRegionCurrencyModelValidator,
			IBOLCountryRegionCurrencyMapper countryRegionCurrencyMapper)
			: base(logger, countryRegionCurrencyRepository, countryRegionCurrencyModelValidator, countryRegionCurrencyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>766cbfa89dd74ae3d9dab3af0f301bfe</Hash>
</Codenesium>*/