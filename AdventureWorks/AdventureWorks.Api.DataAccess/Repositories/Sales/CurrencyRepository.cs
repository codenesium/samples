using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CurrencyRepository: AbstractCurrencyRepository, ICurrencyRepository
	{
		public CurrencyRepository(
			ILogger<CurrencyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e6b6feef735eba82a08e995e850cc5f2</Hash>
</Codenesium>*/