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
			IApiCurrencyRateRequestModelValidator currencyRateModelValidator,
			IBOLCurrencyRateMapper currencyRateMapper)
			: base(logger, currencyRateRepository, currencyRateModelValidator, currencyRateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>1009a136c251740d776beb28944bf139</Hash>
</Codenesium>*/