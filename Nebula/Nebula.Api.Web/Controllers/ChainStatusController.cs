using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
	[Route("api/chainStatus")]
	[ApiVersion("1.0")]
	public class ChainStatusController: AbstractChainStatusController
	{
		public ChainStatusController(
			ServiceSettings settings,
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatusService chainStatusService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       chainStatusService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d9d1153f1ac5601562a84524ef4ba31a</Hash>
</Codenesium>*/