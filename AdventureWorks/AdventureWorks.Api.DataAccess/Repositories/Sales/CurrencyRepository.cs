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
	public partial class CurrencyRepository : AbstractCurrencyRepository, ICurrencyRepository
	{
		public CurrencyRepository(
			ILogger<CurrencyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8068cca8e3100a611dc9eb89616d3a69</Hash>
</Codenesium>*/