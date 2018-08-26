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
	[Route("api/deploymentEnvironments")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>cf9d5d5d504b9a05c1ce3b7e5cd2346a</Hash>
</Codenesium>*/