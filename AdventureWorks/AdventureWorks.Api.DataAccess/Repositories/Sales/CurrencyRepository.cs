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
    <Hash>7cbb1f7002146ee01a558c14d937b7d4</Hash>
</Codenesium>*/