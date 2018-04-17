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
	[Route("api/transactionHistories")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class TransactionHistoryController: AbstractTransactionHistoryController
	{
		public TransactionHistoryController(
			ILogger<TransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTransactionHistory transactionHistoryManager
			)
			: base(logger,
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
    <Hash>ddd70cf452b650ed76063c99120652d7</Hash>
</Codenesium>*/