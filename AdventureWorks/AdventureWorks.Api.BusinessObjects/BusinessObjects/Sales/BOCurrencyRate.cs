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
	public class BOCurrencyRate: AbstractBOCurrencyRate, IBOCurrencyRate
	{
		public BOCurrencyRate(
			ILogger<CurrencyRateRepository> logger,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator)
			: base(logger, currencyRateRepository, currencyRateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>23b514d1e0205ddd57bf229326561a3b</Hash>
</Codenesium>*/