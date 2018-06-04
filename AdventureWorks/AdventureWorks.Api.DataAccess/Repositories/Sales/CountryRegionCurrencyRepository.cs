using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CountryRegionCurrencyRepository: AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
	{
		public CountryRegionCurrencyRepository(
			ILogger<CountryRegionCurrencyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0341cabc5bd1421a53a086ba84c62dd0</Hash>
</Codenesium>*/