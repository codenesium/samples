using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CurrencyRateRepository: AbstractCurrencyRateRepository, ICurrencyRateRepository
	{
		public CurrencyRateRepository(
			ILogger<CurrencyRateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>07b217bc040aad17bf35eacadba0630d</Hash>
</Codenesium>*/