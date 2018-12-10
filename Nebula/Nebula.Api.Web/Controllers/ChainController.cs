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
			IApiChainServerModelMapper chainModelMapper
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
    <Hash>c0eeba6a2fccf037204492c7c08003c0</Hash>
</Codenesium>*/