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
	public class CurrencyRepository: AbstractCurrencyRepository, ICurrencyRepository
	{
		public CurrencyRepository(
			IObjectMapper mapper,
			ILogger<CurrencyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>9ad2ef0c02aef0235a4c31cd3c5da0be</Hash>
</Codenesium>*/