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
			ApplicationContext context,
			ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository,
			ITransactionHistoryArchiveModelValidator transactionHistoryArchiveModelValidator
			) : base(logger,
			         context,
			         transactionHistoryArchiveRepository,
			         transactionHistoryArchiveModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>451115b33a2e2d69b92be3ff4833ee0b</Hash>
</Codenesium>*/