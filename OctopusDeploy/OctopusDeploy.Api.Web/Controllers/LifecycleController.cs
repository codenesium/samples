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
	[Route("api/lifecycles")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LifecycleController : AbstractLifecycleController
	{
		public LifecycleController(
			ApiSettings settings,
			ILogger<LifecycleController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILifecycleService lifecycleService,
			IApiLifecycleModelMapper lifecycleModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lifecycleService,
			       lifecycleModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>212d2c71f595b4a6a2ac4136f5c2f2bd</Hash>
</Codenesium>*/