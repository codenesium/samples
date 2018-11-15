using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/chainStatuses")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ChainStatusController : AbstractChainStatusController
	{
		public ChainStatusController(
			ApiSettings settings,
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatusService chainStatusService,
			IApiChainStatusServerModelMapper chainStatusModelMapper
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
    <Hash>8e9d0480e545461045da15a1e6764246</Hash>
</Codenesium>*/