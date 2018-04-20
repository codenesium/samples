using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/currencies")]
	[ApiVersion("1.0")]
	[Response]
	public class CurrencyController: AbstractCurrencyController
	{
		public CurrencyController(
			ServiceSettings settings,
			ILogger<CurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCurrency currencyManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       currencyManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0898df59a69fef440ca54aeb3ce0272a</Hash>
</Codenesium>*/