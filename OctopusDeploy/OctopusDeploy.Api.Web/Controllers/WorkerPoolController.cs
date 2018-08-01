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
	[Route("api/workerPools")]
	[ApiController]
	[ApiVersion("1.0")]
	public class WorkerPoolController : AbstractWorkerPoolController
	{
		public WorkerPoolController(
			ApiSettings settings,
			ILogger<WorkerPoolController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkerPoolService workerPoolService,
			IApiWorkerPoolModelMapper workerPoolModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workerPoolService,
			       workerPoolModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5341cd9e64aaae839f02fcf85ee2fa90</Hash>
</Codenesium>*/