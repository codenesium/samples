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
	[Route("api/workers")]
	[ApiController]
	[ApiVersion("1.0")]
	public class WorkerController : AbstractWorkerController
	{
		public WorkerController(
			ApiSettings settings,
			ILogger<WorkerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkerService workerService,
			IApiWorkerModelMapper workerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workerService,
			       workerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d03eca4f82ea09439ef21cf49f13bce9</Hash>
</Codenesium>*/