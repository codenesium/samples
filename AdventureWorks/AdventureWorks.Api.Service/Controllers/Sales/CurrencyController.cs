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
	[ServiceFilter(typeof(CurrencyFilter))]
	public class CurrencyController: AbstractCurrencyController
	{
		public CurrencyController(
			ILogger<CurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRepository currencyRepository
			)
			: base(logger,
			       transactionCoordinator,
			       currencyRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c4c893facbb28ef17865c884fc722cbe</Hash>
</Codenesium>*/