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
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/pipelineStepStepRequirements")]
	[ApiVersion("1.0")]
	[Response]
	public class PipelineStepStepRequirementController: AbstractPipelineStepStepRequirementController
	{
		public PipelineStepStepRequirementController(
			ServiceSettings settings,
			ILogger<PipelineStepStepRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStepStepRequirement pipelineStepStepRequirementManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStepRequirementManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0e2990d4d961a1a1ab954f447d19ad94</Hash>
</Codenesium>*/