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
			IApiPipelineStepStepRequirementServerModelMapper pipelineStepStepRequirementModelMapper
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
    <Hash>befaf9c943a08fd846120147c68a7a91</Hash>
</Codenesium>*/