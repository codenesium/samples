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
	public partial class CountryRegionCurrencyRepository : AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
	{
		public CountryRegionCurrencyRepository(
			ILogger<CountryRegionCurrencyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fb4af6c114c7a0dd21d168e5110d626e</Hash>
</Codenesium>*/