using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CurrencyRateRepository: AbstractCurrencyRateRepository, ICurrencyRateRepository
	{
		public CurrencyRateRepository(
			IObjectMapper mapper,
			ILogger<CurrencyRateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>884edb82c3ef9a1bf1c2485c146042c9</Hash>
</Codenesium>*/