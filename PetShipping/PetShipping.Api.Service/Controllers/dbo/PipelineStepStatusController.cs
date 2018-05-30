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
	[Route("api/pipelineStepStatus")]
	[ApiVersion("1.0")]
	public class PipelineStepStatusController: AbstractPipelineStepStatusController
	{
		public PipelineStepStatusController(
			ServiceSettings settings,
			ILogger<PipelineStepStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStepStatus pipelineStepStatusManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStatusManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7ca900247c55e26b6a1080826d30aec2</Hash>
</Codenesium>*/