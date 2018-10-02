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
	[Route("api/chainStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ChainStatuController : AbstractChainStatuController
	{
		public ChainStatuController(
			ApiSettings settings,
			ILogger<ChainStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatuService chainStatuService,
			IApiChainStatuModelMapper chainStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       chainStatuService,
			       chainStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0a6c402e58cf363d2130b20bb23e547e</Hash>
</Codenesium>*/