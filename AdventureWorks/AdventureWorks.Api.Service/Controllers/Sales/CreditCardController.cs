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
	[Route("api/creditCards")]
	[ApiVersion("1.0")]
	[Response]
	public class CreditCardController: AbstractCreditCardController
	{
		public CreditCardController(
			ServiceSettings settings,
			ILogger<CreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCreditCard creditCardManager
			)
			: base(settings,
			       logger,
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
    <Hash>7ffae625f60845b72311cec2ac2af64b</Hash>
</Codenesium>*/