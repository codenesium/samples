using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>b45fc26f0038ce8ae54fcdf397d51a81</Hash>
</Codenesium>*/