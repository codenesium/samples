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
	public class CreditCardController: AbstractCreditCardController
	{
		public CreditCardController(
			ILogger<CreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       creditCardRepository,
			       creditCardModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ed33b2676412a1431d8c543493f0b467</Hash>
</Codenesium>*/