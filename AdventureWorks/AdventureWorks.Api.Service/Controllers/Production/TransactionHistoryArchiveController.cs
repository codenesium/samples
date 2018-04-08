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
	public class TransactionHistoryArchivesController: AbstractTransactionHistoryArchivesController
	{
		public TransactionHistoryArchivesController(
			ILogger<TransactionHistoryArchivesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator
			) : base(logger,
			         transactionCoordinator,
			         transactionHistoryArchiveRepository,
			         transactionHistoryArchiveModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b210e91f9e33b4aca215282ee2720417</Hash>
</Codenesium>*/