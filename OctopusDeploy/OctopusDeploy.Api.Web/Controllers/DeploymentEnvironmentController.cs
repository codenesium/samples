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
	[Route("api/deploymentEnvironments")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DeploymentEnvironmentController : AbstractDeploymentEnvironmentController
	{
		public DeploymentEnvironmentController(
			ApiSettings settings,
			ILogger<DeploymentEnvironmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentEnvironmentService deploymentEnvironmentService,
			IApiDeploymentEnvironmentModelMapper deploymentEnvironmentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deploymentEnvironmentService,
			       deploymentEnvironmentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>23c121c07c29fcce66d259a71a414792</Hash>
</Codenesium>*/