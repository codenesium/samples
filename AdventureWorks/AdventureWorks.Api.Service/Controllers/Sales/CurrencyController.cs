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
	public class CurrencyController: AbstractCurrencyController
	{
		public CurrencyController(
			ILogger<CurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRepository currencyRepository,
			ICurrencyModelValidator currencyModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       currencyRepository,
			       currencyModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4733364033ff26ca9a0d3c5beea55eab</Hash>
</Codenesium>*/