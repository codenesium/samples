using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/rowVersionChecks")]
	[ApiController]
	[ApiVersion("1.0")]
	public class RowVersionCheckController : AbstractRowVersionCheckController
	{
		public RowVersionCheckController(
			ApiSettings settings,
			ILogger<RowVersionCheckController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRowVersionCheckService rowVersionCheckService,
			IApiRowVersionCheckModelMapper rowVersionCheckModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       rowVersionCheckService,
			       rowVersionCheckModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>409a6de94d9b0e5ea1434a2f7b72d56f</Hash>
</Codenesium>*/