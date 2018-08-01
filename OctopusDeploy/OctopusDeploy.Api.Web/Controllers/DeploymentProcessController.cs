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

namespace OctopusDeployNS.Api.Web
{
	[Route("api/deploymentProcesses")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DeploymentProcessController : AbstractDeploymentProcessController
	{
		public DeploymentProcessController(
			ApiSettings settings,
			ILogger<DeploymentProcessController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentProcessService deploymentProcessService,
			IApiDeploymentProcessModelMapper deploymentProcessModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deploymentProcessService,
			       deploymentProcessModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9fa6134bdd4a035038781d15b1d8c603</Hash>
</Codenesium>*/