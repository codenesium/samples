using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
    <Hash>8ed6c7e293e1dc4eb6201eda02122475</Hash>
</Codenesium>*/