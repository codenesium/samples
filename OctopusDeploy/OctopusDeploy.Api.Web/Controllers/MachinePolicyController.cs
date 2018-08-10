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
	[Route("api/machinePolicies")]
	[ApiController]
	[ApiVersion("1.0")]
	public class MachinePolicyController : AbstractMachinePolicyController
	{
		public MachinePolicyController(
			ApiSettings settings,
			ILogger<MachinePolicyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachinePolicyService machinePolicyService,
			IApiMachinePolicyModelMapper machinePolicyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       machinePolicyService,
			       machinePolicyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fb668b52b00e5688b47aa93478a71bce</Hash>
</Codenesium>*/