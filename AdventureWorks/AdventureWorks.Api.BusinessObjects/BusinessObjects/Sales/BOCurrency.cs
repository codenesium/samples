using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCurrency: AbstractBOCurrency, IBOCurrency
	{
		public BOCurrency(
			ILogger<CurrencyRepository> logger,
			ICurrencyRepository currencyRepository,
			ICurrencyModelValidator currencyModelValidator)
			: base(logger, currencyRepository, currencyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>07df36e293a5b872c63074db9c2b37df</Hash>
</Codenesium>*/