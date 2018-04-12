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
	[Route("api/transactionHistoryArchives")]
	public class TransactionHistoryArchiveController: AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       transactionHistoryArchiveRepository,
			       transactionHistoryArchiveModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b4f2e0ab6dee32b35bf0536e3091f12c</Hash>
</Codenesium>*/