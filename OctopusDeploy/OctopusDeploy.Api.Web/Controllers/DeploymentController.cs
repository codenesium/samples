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
	[Route("api/deployments")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class DeploymentController : AbstractDeploymentController
	{
		public DeploymentController(
			ApiSettings settings,
			ILogger<DeploymentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentService deploymentService,
			IApiDeploymentModelMapper deploymentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deploymentService,
			       deploymentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>df1f0125ed77a8315f2e9079c91990ac</Hash>
</Codenesium>*/