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
    <Hash>0e958e1b372ec7c13e4a8e29ac06c1e8</Hash>
</Codenesium>*/