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
	[Route("api/errorLogs")]
	[ApiVersion("1.0")]
	public class ErrorLogController: AbstractErrorLogController
	{
		public ErrorLogController(
			ServiceSettings settings,
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOErrorLog errorLogManager
			)
			: base(settings,
			       logger,
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
    <Hash>d75c3d2263748f8347268b6a42e1ecaf</Hash>
</Codenesium>*/