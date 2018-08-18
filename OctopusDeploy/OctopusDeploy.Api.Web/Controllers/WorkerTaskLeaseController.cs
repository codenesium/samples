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
	[Route("api/workerTaskLeases")]
	[ApiController]
	[ApiVersion("1.0")]
	public class WorkerTaskLeaseController : AbstractWorkerTaskLeaseController
	{
		public WorkerTaskLeaseController(
			ApiSettings settings,
			ILogger<WorkerTaskLeaseController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkerTaskLeaseService workerTaskLeaseService,
			IApiWorkerTaskLeaseModelMapper workerTaskLeaseModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workerTaskLeaseService,
			       workerTaskLeaseModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ef39a0b7b7b4f20fe00583fe73b796d6</Hash>
</Codenesium>*/