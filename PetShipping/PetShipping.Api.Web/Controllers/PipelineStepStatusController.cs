using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/pipelineStepStatus")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PipelineStepStatusController : AbstractPipelineStepStatusController
	{
		public PipelineStepStatusController(
			ApiSettings settings,
			ILogger<PipelineStepStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepStatusService pipelineStepStatusService,
			IApiPipelineStepStatusServerModelMapper pipelineStepStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStatusService,
			       pipelineStepStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d421d113146d6d9c31c53846579c859a</Hash>
</Codenesium>*/