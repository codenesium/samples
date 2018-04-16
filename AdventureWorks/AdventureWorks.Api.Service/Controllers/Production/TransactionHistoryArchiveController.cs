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
	[Route("api/transactionHistoryArchives")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(TransactionHistoryArchiveFilter))]
	public class TransactionHistoryArchiveController: AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository
			)
			: base(logger,
			       transactionCoordinator,
			       transactionHistoryArchiveRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>38de0f51b7c992867ac1ef5d01764ab8</Hash>
</Codenesium>*/