using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
	[Route("api/pipelineStepStatus")]
	[ApiVersion("1.0")]
	public class PipelineStepStatusController: AbstractPipelineStepStatusController
	{
		public PipelineStepStatusController(
			ServiceSettings settings,
			ILogger<PipelineStepStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepStatusService pipelineStepStatusService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStatusService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3defd26096fbf8f2a73bd943e8d2ebc1</Hash>
</Codenesium>*/