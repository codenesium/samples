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
	[Route("api/transactionHistoryArchives")]
	[ApiVersion("1.0")]
	public class TransactionHistoryArchiveController: AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTransactionHistoryArchive transactionHistoryArchiveManager
			)
			: base(logger,
			       transactionCoordinator,
			       transactionHistoryArchiveManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5fdd94220975c4ceaf22a1f47dac947f</Hash>
</Codenesium>*/