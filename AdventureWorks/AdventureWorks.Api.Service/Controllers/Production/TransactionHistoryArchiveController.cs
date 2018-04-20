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
	[Route("api/transactionHistoryArchives")]
	[ApiVersion("1.0")]
	[Response]
	public class TransactionHistoryArchiveController: AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ServiceSettings settings,
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTransactionHistoryArchive transactionHistoryArchiveManager
			)
			: base(settings,
			       logger,
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
    <Hash>fb00ff54c1d79338bbb02ac9aa270d4d</Hash>
</Codenesium>*/