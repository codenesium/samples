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
	[ResponseFilter]
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
    <Hash>2d3ac1e56f51aacc1de49e27cf52bf34</Hash>
</Codenesium>*/