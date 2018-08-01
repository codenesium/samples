using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/errorLogs")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ErrorLogController : AbstractErrorLogController
	{
		public ErrorLogController(
			ApiSettings settings,
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogService errorLogService,
			IApiErrorLogModelMapper errorLogModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       errorLogService,
			       errorLogModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5d66f41cad721f6627209b7d024e6fe7</Hash>
</Codenesium>*/