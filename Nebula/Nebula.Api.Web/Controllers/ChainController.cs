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
	[Route("api/chains")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ChainController : AbstractChainController
	{
		public ChainController(
			ApiSettings settings,
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainService chainService,
			IApiChainModelMapper chainModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       chainService,
			       chainModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dcd16875d4cd9ab717192b51eac68513</Hash>
</Codenesium>*/