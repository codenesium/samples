using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
			IApiPipelineStepStatusModelMapper pipelineStepStatusModelMapper
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
    <Hash>d07700f95c53fbbcaec9be43934a26cc</Hash>
</Codenesium>*/