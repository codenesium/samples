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
	[Route("api/pipelineStepStepRequirements")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PipelineStepStepRequirementController : AbstractPipelineStepStepRequirementController
	{
		public PipelineStepStepRequirementController(
			ApiSettings settings,
			ILogger<PipelineStepStepRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepStepRequirementService pipelineStepStepRequirementService,
			IApiPipelineStepStepRequirementModelMapper pipelineStepStepRequirementModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStepRequirementService,
			       pipelineStepStepRequirementModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2926d2b57185ceba135d682eee48731c</Hash>
</Codenesium>*/