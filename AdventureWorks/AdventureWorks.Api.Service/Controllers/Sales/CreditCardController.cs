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
	[Route("api/creditCards")]
	[ApiVersion("1.0")]
	public class CreditCardController: AbstractCreditCardController
	{
		public CreditCardController(
			ILogger<CreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCreditCard creditCardManager
			)
			: base(logger,
			       transactionCoordinator,
			       creditCardManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b1f6777a897fed1ef19131275f70705a</Hash>
</Codenesium>*/