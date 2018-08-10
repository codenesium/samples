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
	public partial class CurrencyRateRepository : AbstractCurrencyRateRepository, ICurrencyRateRepository
	{
		public CurrencyRateRepository(
			ILogger<CurrencyRateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e07960095c25f958a0953138d2d6bb35</Hash>
</Codenesium>*/