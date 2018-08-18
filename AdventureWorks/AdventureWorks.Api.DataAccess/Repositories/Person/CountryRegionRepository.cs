using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>023e72c571e3e7b3dd77f79b138c9e08</Hash>
</Codenesium>*/