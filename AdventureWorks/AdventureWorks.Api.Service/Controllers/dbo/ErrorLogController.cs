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
	[Route("api/errorLogs")]
	[ApiVersion("1.0")]
	public class ErrorLogController: AbstractErrorLogController
	{
		public ErrorLogController(
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOErrorLog errorLogManager
			)
			: base(logger,
			       transactionCoordinator,
			       errorLogManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0ef235275c7646a4fe3bfd4ec05a694f</Hash>
</Codenesium>*/