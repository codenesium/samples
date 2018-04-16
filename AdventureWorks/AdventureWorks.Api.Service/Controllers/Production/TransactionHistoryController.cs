using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/transactionHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(TransactionHistoryFilter))]
	public class TransactionHistoryController: AbstractTransactionHistoryController
	{
		public TransactionHistoryController(
			ILogger<TransactionHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryRepository transactionHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       transactionHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f1754b806975cb9728ab385393263872</Hash>
</Codenesium>*/