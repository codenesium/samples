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
	[Route("api/serverTasks")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ServerTaskController : AbstractServerTaskController
	{
		public ServerTaskController(
			ApiSettings settings,
			ILogger<ServerTaskController> logger,
			ITransactionCoordinator transactionCoordinator,
			IServerTaskService serverTaskService,
			IApiServerTaskModelMapper serverTaskModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       serverTaskService,
			       serverTaskModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f395807cfd341625eb0699894ab1f5c9</Hash>
</Codenesium>*/