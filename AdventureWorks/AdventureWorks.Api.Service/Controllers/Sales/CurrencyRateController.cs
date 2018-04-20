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
	[Route("api/currencyRates")]
	[ApiVersion("1.0")]
	[Response]
	public class CurrencyRateController: AbstractCurrencyRateController
	{
		public CurrencyRateController(
			ServiceSettings settings,
			ILogger<CurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCurrencyRate currencyRateManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       currencyRateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>166da6764abbab4c343454b49ce7c3d1</Hash>
</Codenesium>*/