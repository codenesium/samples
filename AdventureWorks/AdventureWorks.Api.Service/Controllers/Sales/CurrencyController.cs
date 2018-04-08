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
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRepository currencyRepository,
			ICurrencyModelValidator currencyModelValidator
			) : base(logger,
			         transactionCoordinator,
			         currencyRepository,
			         currencyModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6241471ca5de4f5b61b4bd99db339f2d</Hash>
</Codenesium>*/