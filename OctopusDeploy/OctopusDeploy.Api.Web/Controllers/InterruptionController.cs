using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/interruptions")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class InterruptionController : AbstractInterruptionController
	{
		public InterruptionController(
			ApiSettings settings,
			ILogger<InterruptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IInterruptionService interruptionService,
			IApiInterruptionModelMapper interruptionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       interruptionService,
			       interruptionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1cf8703719e39c60028f404c90ba6765</Hash>
</Codenesium>*/