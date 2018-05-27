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
			IApiCurrencyRequestModelValidator currencyModelValidator,
			IBOLCurrencyMapper currencyMapper)
			: base(logger, currencyRepository, currencyModelValidator, currencyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>350baee5b50b4d0cba2e0e1c9d5c0809</Hash>
</Codenesium>*/