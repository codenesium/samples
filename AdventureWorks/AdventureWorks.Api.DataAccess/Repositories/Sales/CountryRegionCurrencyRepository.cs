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
			IDALCountryRegionCurrencyMapper mapper,
			ILogger<CountryRegionCurrencyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>090cd9784a28e2ba4b41431ba31a5e7d</Hash>
</Codenesium>*/