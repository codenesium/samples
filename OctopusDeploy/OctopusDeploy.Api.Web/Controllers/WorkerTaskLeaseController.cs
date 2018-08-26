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
	[Route("api/workerTaskLeases")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>a3e42d573aba6e07de499ad33c33a13d</Hash>
</Codenesium>*/