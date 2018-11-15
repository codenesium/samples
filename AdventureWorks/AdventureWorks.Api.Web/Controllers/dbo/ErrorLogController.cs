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
	[Route("api/errorLogs")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ErrorLogController : AbstractErrorLogController
	{
		public ErrorLogController(
			ApiSettings settings,
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogService errorLogService,
			IApiErrorLogServerModelMapper errorLogModelMapper
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
    <Hash>f4fe66bc8fc4ea3149dbbe505e8c444d</Hash>
</Codenesium>*/