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
	[Route("api/creditCards")]
	public class CreditCardsController: AbstractCreditCardsController
	{
		public CreditCardsController(
			ILogger<CreditCardsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator
			) : base(logger,
			         transactionCoordinator,
			         creditCardRepository,
			         creditCardModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fe15d6bbac766624be819667262b9ef6</Hash>
</Codenesium>*/