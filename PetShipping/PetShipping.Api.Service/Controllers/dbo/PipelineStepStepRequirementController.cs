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
    <Hash>3af8e8929a2f5d3ac8bdf82771ea912c</Hash>
</Codenesium>*/