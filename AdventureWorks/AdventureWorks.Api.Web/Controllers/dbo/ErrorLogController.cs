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
	[Route("api/errorLogs")]
	[ApiVersion("1.0")]
	public class ErrorLogController: AbstractErrorLogController
	{
		public ErrorLogController(
			ServiceSettings settings,
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogService errorLogService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       errorLogService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2eac40bf013f437c1edda4946df3aeb8</Hash>
</Codenesium>*/