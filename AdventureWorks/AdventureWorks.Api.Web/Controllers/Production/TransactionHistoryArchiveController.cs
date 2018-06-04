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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/transactionHistoryArchives")]
	[ApiVersion("1.0")]
	public class TransactionHistoryArchiveController: AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ServiceSettings settings,
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveService transactionHistoryArchiveService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionHistoryArchiveService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cf579a8a0bed6c97ef469d38f5c530b8</Hash>
</Codenesium>*/