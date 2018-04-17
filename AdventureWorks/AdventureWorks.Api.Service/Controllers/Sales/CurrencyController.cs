using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/currencies")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class CurrencyController: AbstractCurrencyController
	{
		public CurrencyController(
			ILogger<CurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCurrency currencyManager
			)
			: base(logger,
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
    <Hash>03964460fba33eff8c40610aabd6dced</Hash>
</Codenesium>*/