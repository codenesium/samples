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
	[Route("api/machinePolicies")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>9f5daa44543455f12969068c54ee133f</Hash>
</Codenesium>*/