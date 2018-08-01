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
	[Route("api/timestampChecks")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TimestampCheckController : AbstractTimestampCheckController
	{
		public TimestampCheckController(
			ApiSettings settings,
			ILogger<TimestampCheckController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITimestampCheckService timestampCheckService,
			IApiTimestampCheckModelMapper timestampCheckModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       timestampCheckService,
			       timestampCheckModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d66622f6cb25a6361a4045536b2cd18c</Hash>
</Codenesium>*/