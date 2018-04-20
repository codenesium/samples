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
	[Route("api/transactionHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class TransactionHistoryController: AbstractTransactionHistoryController
	{
		public TransactionHistoryController(
			ServiceSettings settings,
			ILogger<TransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTransactionHistory transactionHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2abab91adafd18adfc1725531b34eb1c</Hash>
</Codenesium>*/