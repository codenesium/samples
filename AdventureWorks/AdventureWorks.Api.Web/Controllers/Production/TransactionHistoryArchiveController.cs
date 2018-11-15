using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/transactionHistoryArchives")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class TransactionHistoryArchiveController : AbstractTransactionHistoryArchiveController
	{
		public TransactionHistoryArchiveController(
			ApiSettings settings,
			ILogger<TransactionHistoryArchiveController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionHistoryArchiveService transactionHistoryArchiveService,
			IApiTransactionHistoryArchiveServerModelMapper transactionHistoryArchiveModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionHistoryArchiveService,
			       transactionHistoryArchiveModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>52745853ec15095a1e9c55993f5a6660</Hash>
</Codenesium>*/