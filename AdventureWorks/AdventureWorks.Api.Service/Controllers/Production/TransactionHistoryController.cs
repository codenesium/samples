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
			ApplicationContext context,
			ITransactionHistoryRepository transactionHistoryRepository,
			ITransactionHistoryModelValidator transactionHistoryModelValidator
			) : base(logger,
			         context,
			         transactionHistoryRepository,
			         transactionHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7b8658c7aa4a7b5a90495b0aa5d6a082</Hash>
</Codenesium>*/