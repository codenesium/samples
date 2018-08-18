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
	[Route("api/deploymentRelatedMachines")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DeploymentRelatedMachineController : AbstractDeploymentRelatedMachineController
	{
		public DeploymentRelatedMachineController(
			ApiSettings settings,
			ILogger<DeploymentRelatedMachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeploymentRelatedMachineService deploymentRelatedMachineService,
			IApiDeploymentRelatedMachineModelMapper deploymentRelatedMachineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deploymentRelatedMachineService,
			       deploymentRelatedMachineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac3c918221792f787a32fb61bc4eb0f3</Hash>
</Codenesium>*/