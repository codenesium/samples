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
	[Route("api/errorLogs")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ErrorLogFilter))]
	public class ErrorLogController: AbstractErrorLogController
	{
		public ErrorLogController(
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogRepository errorLogRepository
			)
			: base(logger,
			       transactionCoordinator,
			       errorLogRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>618753e415a5d4405d907ee39cebca56</Hash>
</Codenesium>*/