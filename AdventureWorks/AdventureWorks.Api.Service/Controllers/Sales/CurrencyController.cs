using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/currencies")]
	public class CurrenciesController: AbstractCurrenciesController
	{
		public CurrenciesController(
			ILogger<CurrenciesController> logger,
			ApplicationContext context,
			ICurrencyRepository currencyRepository,
			ICurrencyModelValidator currencyModelValidator
			) : base(logger,
			         context,
			         currencyRepository,
			         currencyModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bb50c4d2dcb4bccc2de94b899b63f29b</Hash>
</Codenesium>*/