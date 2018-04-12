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
	[Route("api/transactionHistories")]
	public class TransactionHistoryController: AbstractTransactionHistoryController
	{
		public TransactionHistoryController(
			ILogger<TransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       transactionHistoryRepository,
			       transactionHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>02d7ba99b44f7acb56aa5d55286e6fc1</Hash>
</Codenesium>*/