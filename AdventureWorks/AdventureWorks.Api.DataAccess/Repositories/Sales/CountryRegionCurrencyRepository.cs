using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CountryRegionCurrencyRepository: AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
	{
		public CountryRegionCurrencyRepository(
			IObjectMapper mapper,
			ILogger<CountryRegionCurrencyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c515b21cfb0e70c363047e194d9bea91</Hash>
</Codenesium>*/