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
			IApiTimestampCheckServerModelMapper timestampCheckModelMapper
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
    <Hash>9ac6a3331a1529080f66f55bb8620f88</Hash>
</Codenesium>*/