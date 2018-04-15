using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/currencies")]
	[ApiVersion("1.0")]
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
    <Hash>6bc6165a73327ec58fc76e1c85360ca3</Hash>
</Codenesium>*/