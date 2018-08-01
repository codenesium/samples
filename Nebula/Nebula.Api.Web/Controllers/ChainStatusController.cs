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
	[Route("api/chainStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ChainStatusController : AbstractChainStatusController
	{
		public ChainStatusController(
			ApiSettings settings,
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatusService chainStatusService,
			IApiChainStatusModelMapper chainStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       chainStatusService,
			       chainStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4f9e574a8763bbce6008af3a2b107c51</Hash>
</Codenesium>*/