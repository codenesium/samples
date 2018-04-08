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
	public class TransactionHistoriesController: AbstractTransactionHistoriesController
	{
		public TransactionHistoriesController(
			ILogger<TransactionHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         transactionHistoryRepository,
			         transactionHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b95bcf3c0f073d856c292be00a5c7ddb</Hash>
</Codenesium>*/