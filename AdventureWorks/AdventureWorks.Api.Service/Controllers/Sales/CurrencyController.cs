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
    <Hash>78e5dc4eed046cc4ad81f471d3a2161f</Hash>
</Codenesium>*/