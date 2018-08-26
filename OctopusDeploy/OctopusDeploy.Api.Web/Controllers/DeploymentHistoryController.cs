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
	[Route("api/deploymentHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class DeploymentHistoryController : AbstractDeploymentHistoryController
	{
		public DeploymentHistoryController(
			ApiSettings settings,
			ILogger<DeploymentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentHistoryService deploymentHistoryService,
			IApiDeploymentHistoryModelMapper deploymentHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deploymentHistoryService,
			       deploymentHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ba669d88d064036d1f0b5b23fb3625fb</Hash>
</Codenesium>*/