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
			IDALCurrencyRateMapper mapper,
			ILogger<CurrencyRateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c5265380a1c8d7072980b8b688ac92ff</Hash>
</Codenesium>*/