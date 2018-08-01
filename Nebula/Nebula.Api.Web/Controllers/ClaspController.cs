using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Web
{
	[Route("api/clasps")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ClaspController : AbstractClaspController
	{
		public ClaspController(
			ApiSettings settings,
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspService claspService,
			IApiClaspModelMapper claspModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       claspService,
			       claspModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>07ebf2ffeaf3780a526837640688a37c</Hash>
</Codenesium>*/