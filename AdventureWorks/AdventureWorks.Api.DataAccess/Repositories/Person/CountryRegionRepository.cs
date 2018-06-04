using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CountryRegionRepository: AbstractCountryRegionRepository, ICountryRegionRepository
	{
		public CountryRegionRepository(
			ILogger<CountryRegionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>680aa4c6c7898a3a4773882d17e1e1d3</Hash>
</Codenesium>*/