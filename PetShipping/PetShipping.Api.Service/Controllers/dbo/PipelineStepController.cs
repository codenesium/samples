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
	[Route("api/pipelineSteps")]
	[ApiVersion("1.0")]
	[Response]
	public class PipelineStepController: AbstractPipelineStepController
	{
		public PipelineStepController(
			ServiceSettings settings,
			ILogger<PipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStep pipelineStepManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e0d27b408e34eb9ab57b234aeddc4724</Hash>
</Codenesium>*/