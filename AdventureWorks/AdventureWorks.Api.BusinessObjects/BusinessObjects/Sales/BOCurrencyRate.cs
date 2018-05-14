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
			IApiCurrencyRateModelValidator currencyRateModelValidator)
			: base(logger, currencyRateRepository, currencyRateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0f1979ed6cfb18f7b6b6706ad985982e</Hash>
</Codenesium>*/