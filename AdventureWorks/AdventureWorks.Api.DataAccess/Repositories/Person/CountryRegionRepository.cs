using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class CountryRegionRepository : AbstractCountryRegionRepository, ICountryRegionRepository
	{
		public CountryRegionRepository(
			ILogger<CountryRegionRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9747369e1d8b32922a94d406d32297a5</Hash>
</Codenesium>*/