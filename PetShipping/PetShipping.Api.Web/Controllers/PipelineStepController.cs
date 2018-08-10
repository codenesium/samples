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
	[Route("api/pipelineSteps")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PipelineStepController : AbstractPipelineStepController
	{
		public PipelineStepController(
			ApiSettings settings,
			ILogger<PipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepService pipelineStepService,
			IApiPipelineStepModelMapper pipelineStepModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepService,
			       pipelineStepModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7720e29d5044f95c3630259c001b2181</Hash>
</Codenesium>*/